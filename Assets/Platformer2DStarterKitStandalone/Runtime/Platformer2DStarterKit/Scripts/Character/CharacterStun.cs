using UnityEngine;

namespace Platformer2DStarterKit {
    public class CharacterStun : MonoBehaviour {
        public Character Character;

        private float stunTimer = 0f;

        public void Stun(float time) {
            stunTimer = time;
            Character.CurrentState = Character.State.Stunned;
            Character.MovementExecution.Reinitialize();
            enabled = true;
        }

        private void FixedUpdate() {
            if (stunTimer > 0f) {
                stunTimer -= Time.fixedDeltaTime;
            } else if (Character.CurrentState == Character.State.Stunned) {
                Character.CurrentState = Character.State.Idle;
                enabled = false;
            }
        }

    }
}
