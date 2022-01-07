using UnityEngine;

namespace Platformer2DStarterKit.Physics {
    public class CharacterFriction : MonoBehaviour {
        public Character Character;
        public Check Check;
        public float Drag;

        private void Awake() {
            Character.StateChanged += Character_StateChanged;
        }
        private void OnDestroy() {
            Character.StateChanged -= Character_StateChanged;
        }

        private void Character_StateChanged(Character character, Character.State currentState, Character.State previousState) {
            enabled = currentState == Character.State.Idle;
        }

        private void FixedUpdate() {
            if (Check.Evaluate())
                Character.Rigidbody.drag = Drag;
            else
                Character.Rigidbody.drag = 0f;
        }

        private void OnDisable() {
            Character.Rigidbody.drag = 0f;
        }

    }
}
