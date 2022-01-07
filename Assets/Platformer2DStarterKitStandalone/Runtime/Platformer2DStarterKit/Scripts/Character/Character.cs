using UnityEngine;

namespace Platformer2DStarterKit {
    public class Character : MonoBehaviour, IPlatformable {
        public enum State {
            Idle, Moving, Jumping, Stunned
        };
        private State currentState;
        public State CurrentState {
            get => currentState;
            set {
                if (currentState == value) return;
                State previousState = currentState;
                currentState = value;
                StateChanged?.Invoke(this, currentState, previousState);
            }
        }
        public delegate void StateChangedAction(Character character, State currentState, State previousState);
        public event StateChangedAction StateChanged;
        public CharacterInput Input;
        public Rigidbody2D Rigidbody;
        public MovementExecution MovementExecution;
        MovementExecution IPlatformable.MovementExecution => MovementExecution;
        public bool IsMoveable => GroundCheck.Evaluate();
        /// <summary>
        /// Detects for ground, which allows jumping and/or movement.
        /// </summary>
        public GroundCheck GroundCheck;

        private void OnEnable() {
            Input.Dir = CharacterInput.Direction.None;
            Input.JumpRequest = false;
        }

    }
}
