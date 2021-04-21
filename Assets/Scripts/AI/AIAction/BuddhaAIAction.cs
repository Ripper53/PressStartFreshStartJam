using System.Collections.Generic;
using UnityEngine;
using Platformer2DStarterKit.Utility;
using Platformer2DStarterKit.AI;

[System.Serializable]
public class BuddhaAIAction : IAIAction, IAIAction.IInitialize {
    public Transform PlayerTransform;
    public float MinMoveTime, MaxMoveTime;
    public float MinNewMovePointTime, MaxNewMovePointTime;
    public Transform MovePoints;
    public LayerMask ObstacleLayerMask, KillLayerMask;
    public Hand RightHand, LeftHand;

    [System.Serializable]
    public class Hand {
        public Transform Arm, Origin;
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
            float targetAngle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90f;

            Arm.rotation = Quaternion.Euler(0f, 0f, Mathf.SmoothDampAngle(Arm.eulerAngles.z, targetAngle, ref vel, aimTime, Mathf.Infinity, Time.fixedDeltaTime));

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

            foreach (RaycastHit2D h in Physics2D.BoxCastAll(Origin.position, raySize, Angle, Direction, dis, Action.KillLayerMask))
                CharacterDeath.Kill(h.collider);
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
    }

    public bool Execute(AIActionList.Token token) {
        if (!newMovePointTimer.Execute(Time.fixedDeltaTime)) {
            if (point)
                movePoints.Add(point);
            newMovePointTimer.SetTime(Random.Range(MinNewMovePointTime, MaxNewMovePointTime));
            int index = Random.Range(0, movePoints.Count);
            point = movePoints[index];
            movePoints.RemoveAt(index);
            moveTime = Random.Range(MinMoveTime, MaxMoveTime);
        }

        // Movement
        token.Source.MovementExecution.AddPosition(Vector2.SmoothDamp(token.Source.Rigidbody.position, point.position, ref vel, moveTime, Mathf.Infinity, Time.fixedDeltaTime) - token.Source.Rigidbody.position);

        // Ray
        RightHand.Ray(PlayerTransform.position);
        LeftHand.Ray(PlayerTransform.position);

        return true;
    }

}
