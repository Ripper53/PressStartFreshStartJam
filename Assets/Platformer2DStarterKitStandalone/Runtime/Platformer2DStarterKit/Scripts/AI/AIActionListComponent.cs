using UnityEngine;
using Platformer2DStarterKit.Utility;

namespace Platformer2DStarterKit.AI {
    public class AIActionListComponent : MonoBehaviour, ICharacter {
        public virtual Vector2 Position {
            get => Transform.position;
            set => Transform.position = value;
        }
        public virtual float Angle {
            get => Rigidbody.rotation;
            set => Transform.rotation = Quaternion.Euler(0f, 0f, value);
        }

        public WanderAIAction Wander;
        WanderAIAction ICharacter.Wander => Wander;
        public Transform Transform;
        Transform ICharacter.Transform => Transform;
        public Rigidbody2D Rigidbody;
        Rigidbody2D ICharacter.Rigidbody => Rigidbody;
        public SpriteRenderer SpriteRenderer;
        SpriteRenderer ICharacter.SpriteRenderer => SpriteRenderer;
        public FrameAnimator FrameAnimator;
        FrameAnimator ICharacter.Animator => FrameAnimator;
        public Character Character;
        Character ICharacter.Character => Character;
        public CharacterMovement CharacterMovement;
        CharacterMovement ICharacter.Movement => CharacterMovement;
        public CharacterStun CharacterStun;
        CharacterStun ICharacter.Stun => CharacterStun;
        public CharacterJump Jump;
        CharacterJump ICharacter.Jump => Jump;
        public CharacterDeath Death;
        CharacterDeath ICharacter.Death => Death;
        public MovementExecution MovementExecution;
        MovementExecution ICharacter.MovementExecution => MovementExecution;
        public GradientRate Speed;
        GradientRate ICharacter.Speed => Speed;
        public AIActionList ActionList;
        AIActionList ICharacter.ActionList => ActionList;

        public virtual void Hide() {
            throw new System.NotImplementedException();
        }

        public virtual void Show() {
            throw new System.NotImplementedException();
        }

        [SerializeField]
        private PoolerRepository poolerRepository;
        private void Awake() {
            ActionList = new AIActionList(this, poolerRepository);
        }

        private void FixedUpdate() {
            ActionList.Execute();
        }

        private void OnDisable() {
            ActionList.ReinitializeActions();
        }

    }
}
