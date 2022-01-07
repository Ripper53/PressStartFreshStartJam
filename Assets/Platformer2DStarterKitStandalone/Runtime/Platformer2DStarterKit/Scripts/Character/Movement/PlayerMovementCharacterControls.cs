using UnityEngine.InputSystem;

namespace Platformer2DStarterKit {
    public class PlayerMovementCharacterControls : PlayerControls<PlayerCharacterInput> {
        public Character Character;

        protected override void AddListener(PlayerCharacterInput input) {
            input.Movement.Horizontal.performed += Horizontal_performed;
            input.Movement.Horizontal.canceled += Horizontal_canceled;
        }

        protected override void RemoveListener(PlayerCharacterInput input) {
            input.Movement.Horizontal.performed -= Horizontal_performed;
            input.Movement.Horizontal.canceled -= Horizontal_canceled;
        }

        private void Horizontal_performed(InputAction.CallbackContext obj) {
            Character.Input.Dir = obj.ReadValue<float>() > 0f ? CharacterInput.Direction.Right : CharacterInput.Direction.Left;
        }

        private void Horizontal_canceled(InputAction.CallbackContext obj) {
            Character.Input.Dir = CharacterInput.Direction.None;
        }

    }
}
