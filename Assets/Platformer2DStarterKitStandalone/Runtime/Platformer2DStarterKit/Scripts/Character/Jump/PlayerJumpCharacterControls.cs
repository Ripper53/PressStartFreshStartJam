using UnityEngine.InputSystem;

namespace Platformer2DStarterKit {
    public class PlayerJumpCharacterControls : PlayerControls<PlayerCharacterInput> {
        public Character Character;

        protected override void AddListener(PlayerCharacterInput input) {
            input.Movement.Jump.performed += Jump_performed;
            input.Movement.Jump.canceled += Jump_canceled;
        }
        protected override void RemoveListener(PlayerCharacterInput input) {
            input.Movement.Jump.performed -= Jump_performed;
            input.Movement.Jump.canceled -= Jump_canceled;
        }

        private bool jumpRequest = false;
        private void Jump_performed(InputAction.CallbackContext obj) {
            jumpRequest = true;
            Character.Input.JumpRequest = true;
        }
        private void Jump_canceled(InputAction.CallbackContext obj) {
            jumpRequest = false;
        }

        private void Update() {
            if (jumpRequest)
                Character.Input.JumpRequest = true;
        }

    }
}
