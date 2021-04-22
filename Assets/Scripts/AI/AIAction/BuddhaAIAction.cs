using System.Collections.Generic;
using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;
using Platformer2DStarterKit.AI;
using UnityEngine.Rendering;

[System.Serializable]
public class BuddhaAIAction : IAIAction, IAIAction.IInitialize {
    public AIActionListComponent AIActionListComponent;
    public Transform PlayerTransform;
    [Header("Movement")]
    public float MinMoveTime;
    public float MaxMoveTime;
    public float MinNewMovePointTime, MaxNewMovePointTime;
    public Transform MovePoints;
    public Transform LastPoint;
    [Header("Inverted")]
    public SpriteAnimationBase InvertedAnimation;
    public Sprite InvertedArmsSprite;
    public SpriteRenderer ShouldersSpriteRenderer;
    public Sprite InvertedShouldersSprite;
    [Header("Laser")]
    public OneShotAudioEffectPooler LaserHitOneShotAudioEffectPooler;
    public LayerMask ObstacleLayerMask;
    public LayerMask KillLayerMask;
    public Hand RightHand, LeftHand;
    [Header("Spawn")]
    public SpawnPooler SpawnPooler;
    public float MinSpawnTime, MaxSpawnTime;
    public int MaxSpawnCount;
    [Header("Head")]
    public SortingGroup BuddhaSortingGroup;
    public AIActionListComponent BuddhaHeadAI;
    [Header("Treasure")]
    public GameObject TreasureObj;

    [System.Serializable]
    public class Hand {
        public Transform Arm, Origin;
        public SpriteRenderer ArmSpriteRenderer;
        public float NewAimTime;
        public float MinAimTime, MaxAimTime;
        [System.NonSerialized]
        public BuddhaAIAction Action;
        [System.NonSerialized]
        public GameObject LaserGameObject;
        [System.NonSerialized]
        public Transform LaserTransform;
        [System.NonSerialized]
        public SpriteRenderer LaserSpriteRenderer;

        private float Angle => Arm.eulerAngles.z;
        private Vector2 Direction => -Arm.up;

        private float vel = 0f;
        private float aimTime;
        private readonly Timer newAimTimer = new Timer();

        public void Ray(Vector2 target) {
            if (!newAimTimer.Execute(Time.fixedDeltaTime)) {
                newAimTimer.SetTime(NewAimTime);
                aimTime = Random.Range(MinAimTime, MaxAimTime);
            }

            Vector2 dir = target - (Vector2)Origin.position;
            Rest((Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90f);

            const float maxDistance = 1000f;
            LaserTransform.position = Origin.position;
            LaserTransform.rotation = Quaternion.Euler(0f, 0f, Angle);
            Vector2 raySize = new Vector2(0.375f, 0.5f);
            RaycastHit2D hit = Physics2D.BoxCast(Origin.position, raySize, Angle, Direction, maxDistance, Action.ObstacleLayerMask);
            float dis;
            if (hit.collider) {
                dis = hit.distance;
                LaserSpriteRenderer.size = new Vector2(1f, (dis * (1f / 0.625f)) + 0.5f);
            } else {
                dis = maxDistance;
                LaserSpriteRenderer.size = new Vector2(1f, dis);
            }
            LaserGameObject.SetActive(true);

            foreach (RaycastHit2D h in Physics2D.BoxCastAll(Origin.position, raySize, Angle, Direction, dis, Action.KillLayerMask)) {
                OneShotAudioEffect effect = Action.LaserHitOneShotAudioEffectPooler.Get();
                effect.Set(h.transform.position);
                effect.gameObject.SetActive(true);
                CharacterDeath.Kill(h.collider);
            }
        }

        public void Rest(float angle) {
            Arm.rotation = Quaternion.Euler(0f, 0f, Mathf.SmoothDampAngle(Arm.eulerAngles.z, angle, ref vel, aimTime, Mathf.Infinity, Time.fixedDeltaTime));
        }
    }

    private Vector2 vel = Vector2.zero;
    private float moveTime;
    private Transform point;
    private readonly Timer newMovePointTimer = new Timer();
    private readonly List<Transform> movePoints = new List<Transform>();

    public void Initialize(IAIAction.IInitialize.Token token) {
        movePoints.Capacity = MovePoints.childCount;
        foreach (Transform t in MovePoints)
            movePoints.Add(t);

        spawnTimer.SetTime(Random.Range(MinSpawnTime, MaxSpawnTime));
    }

    public bool Execute(AIActionList.Token token) {
        if (lastPhase) {
            RightHand.Rest(0f);
            LeftHand.Rest(0f);
        } else {
            if (!newMovePointTimer.Execute(Time.fixedDeltaTime)) {
                newMovePointTimer.SetTime(Random.Range(MinNewMovePointTime, MaxNewMovePointTime));
                float dis = Vector2.Distance(PlayerTransform.position, movePoints[0].position);
                int index = 0;
                for (int i = 1, count = movePoints.Count; i < count; i++) {
                    if (Vector2.Distance(PlayerTransform.position, movePoints[i].position) < dis)
                        index = i;
                }
                if (point)
                    movePoints.Add(point);
                point = movePoints[index];
                movePoints.RemoveAt(index);
                moveTime = Random.Range(MinMoveTime, MaxMoveTime);
            }

            // Ray
            RightHand.Ray(PlayerTransform.position);
            LeftHand.Ray(PlayerTransform.position);
        }
        // Movement
        token.Source.MovementExecution.AddPosition(Vector2.SmoothDamp(token.Source.Rigidbody.position, point.position, ref vel, moveTime, Mathf.Infinity, Time.fixedDeltaTime) - token.Source.Rigidbody.position);

        // Spawn
        RandomSpawn(token);

        return true;
    }

    private readonly Timer spawnTimer = new Timer();
    private readonly List<Spawn> spawning = new List<Spawn>();
    private readonly List<ICharacter> spawnedCharacters = new List<ICharacter>();
    private void RandomSpawn(AIActionList.Token token) {
        if (spawnedCharacters.Count >= MaxSpawnCount || spawnTimer.Execute(Time.fixedDeltaTime)) return;
        if (lastPhase)
            spawnTimer.SetTime(0.25f);
        else
            spawnTimer.SetTime(Random.Range(MinSpawnTime, MaxSpawnTime));
        RaycastHit2D hit = Physics2D.CircleCast(token.Source.Rigidbody.position, 0.5f, Random.insideUnitCircle.normalized, Mathf.Infinity, ObstacleLayerMask);
        if (!hit.collider) return;
        Spawn spawn = SpawnPooler.Get();
        spawning.Add(spawn);
        spawn.Spawned += Spawn_Spawned;
        spawn.transform.position = hit.centroid;
        spawn.gameObject.SetActive(true);
    }

    private void Spawn_Spawned(Spawn source, AIActionListComponent ai) {
        spawning.Remove(source);
        spawnedCharacters.Add(ai);
        void SpawnedDeath_Died(CharacterDeath source, CharacterDeadBody deadBody) {
            spawnedCharacters.Remove(ai);
            source.Died -= SpawnedDeath_Died;
        }
        ai.Death.Died += SpawnedDeath_Died;
        source.Spawned -= Spawn_Spawned;
    }

    private bool lastPhase = false;
    public void LastPhase(ICharacter character) {
        lastPhase = true;
        spawnTimer.SetTime(1f);
        MaxSpawnCount = 32;
        point = LastPoint;
        character.Animator.SetAnimation(InvertedAnimation);
        ShouldersSpriteRenderer.sprite = InvertedShouldersSprite;
        RightHand.ArmSpriteRenderer.sprite = InvertedArmsSprite;
        LeftHand.ArmSpriteRenderer.sprite = InvertedArmsSprite;
        RightHand.LaserGameObject.SetActive(false);
        LeftHand.LaserGameObject.SetActive(false);
        BuddhaSortingGroup.sortingLayerName = "Default";
        BuddhaHeadAI.transform.SetParent(null);
        BuddhaHeadAI.Death.Died += BuddhaHeadAIDeath_Died;
        BuddhaHeadAI.gameObject.SetActive(true);
    }

    private void BuddhaHeadAIDeath_Died(CharacterDeath source, CharacterDeadBody deadBody) {
        AIActionListComponent.ActionList.ClearActions();
        foreach (Spawn spawn in spawning)
            spawn.gameObject.SetActive(false);
        spawning.Clear();
        while (spawnedCharacters.Count > 0)
            spawnedCharacters[0].Death.Die();
        TreasureObj.SetActive(true);
    }

}
