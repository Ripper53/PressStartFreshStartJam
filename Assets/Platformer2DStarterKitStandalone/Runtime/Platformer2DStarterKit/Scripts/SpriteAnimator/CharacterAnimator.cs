using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class CharacterAnimator : MonoBehaviour {
        public Character Character;
        public SpriteAnimator SpriteAnimator;
        public SpriteAnimationBase IdleAnimation, WalkAnimation, JumpAnimation;
        public ParticleSystem JumpParticleSystem;

        private void OnEnable() {
            Character_StateChanged(Character, Character.CurrentState, Character.CurrentState);
            Character.StateChanged += Character_StateChanged;
        }
        private void OnDisable() {
            Character.StateChanged -= Character_StateChanged;
        }

        private void Character_StateChanged(Character character, Character.State currentState, Character.State previousState) {
            switch (currentState) {
                case Character.State.Idle:
                    SpriteAnimator.SetAnimation(IdleAnimation);
                    break;
                case Character.State.Moving:
                    SpriteAnimator.SetAnimation(WalkAnimation);
                    break;
                case Character.State.Jumping:
                    SpriteAnimator.SetAnimation(JumpAnimation);
                    JumpParticleSystem.Play();
                    break;
            }
        }

    }
}
