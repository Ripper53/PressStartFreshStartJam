using UnityEngine;

namespace Platformer2DStarterKit {
    /// <summary>
    /// Allows character to move using its input direction.
    /// </summary>
    public class CharacterMovement : MonoBehaviour {
        public enum MovementType {
            /// <summary>
            /// Allow movement on ground only.
            /// </summary>
            GroundOnly,
            /// <summary>
            /// Allow movement on ground and in air.
            /// </summary>
            GroundAndAir
        };
        public MovementType Type;

        public Character Character;
        public MovementExecution MovementExecution;
        public GradientRate Speed;
        public Check RightWall, LeftWall;

        private Character.State previousState;
        private CharacterInput.Direction previousDirection;

        private void OnEnable() {
            previousState = Character.CurrentState;
            previousDirection = Character.Input.Dir;
        }

        private void FixedUpdate() {
            switch (Character.CurrentState) {
                case Character.State.Stunned:
                    Speed.Reinitialize();
                    break;
                default:
                    Move();
                    if (Type == MovementType.GroundOnly && Character.GroundCheck.Evaluate()) {
                        int savedLayer = Character.gameObject.layer;
                        Character.gameObject.layer = 2;
                        bool v = !Character.GroundCheck.Check.Evaluate();
                        Character.gameObject.layer = savedLayer;
                        if (v && previousState == Character.State.Moving && Character.CurrentState == Character.State.Idle && Character.Input.Dir == CharacterInput.Direction.None) {
                            // If Character falls off of an edge, and does not want to move, drop straight below!
                            Character.MovementExecution.Reinitialize();
                            Character.MovementExecution.Rigidbody.velocity = Vector2.zero;
                        }
                    }
                    break;
            }
            previousState = Character.CurrentState;
            if (Character.Input.Dir != CharacterInput.Direction.None)
                previousDirection = Character.Input.Dir;
        }

        private bool Move() {
            if (Character.CurrentState == Character.State.Jumping) return false;
            if (Character.GroundCheck.Evaluate()) {
                // We are on the ground!
                if (MoveInInputDirection())
                    return true;
                float speed = Speed.GetDescendingValue();
                if (speed != 0f)
                    MovementExecution.AddPosition(new Vector2((speed * (int)previousDirection) * Time.fixedDeltaTime, 0f));
            } else if (Type == MovementType.GroundAndAir) {
                // We are in the air!
                switch (Character.Input.Dir) {
                    case CharacterInput.Direction.Right:
                        if (RightWall.Evaluate()) return false;
                        Character.CurrentState = Character.State.Moving;
                        /*
                        // Reset speed if we were already moving in the opposite direction!
                        if (Character.Rigidbody.velocity.x < 0f)
                            Speed.Reset();*/
                        Character.Rigidbody.velocity = new Vector2(Speed.GetAscendingValue(), Character.Rigidbody.velocity.y);
                        return true;
                    case CharacterInput.Direction.Left:
                        if (LeftWall.Evaluate()) return false;
                        Character.CurrentState = Character.State.Moving;
                        /*
                        // Reset speed if we were already moving in the opposite direction!
                        if (Character.Rigidbody.velocity.x > 0f)
                            Speed.Reset();*/
                        Character.Rigidbody.velocity = new Vector2(-Speed.GetAscendingValue(), Character.Rigidbody.velocity.y);
                        return true;
                    default:
                        Character.CurrentState = Character.State.Idle;
                        Character.Rigidbody.velocity = new Vector2(Speed.GetDescendingValue() * (int)previousDirection, Character.Rigidbody.velocity.y);
                        return true;
                }
            } else {
                Character.CurrentState = Character.State.Idle;
            }
            return false;
        }

        /// <returns>True if moving, otherwise false.</returns>
        private bool MoveInInputDirection() {
            switch (Character.Input.Dir) {
                case CharacterInput.Direction.Right:
                    Character.CurrentState = Character.State.Moving;
                    Character.Rigidbody.velocity = Vector2.zero;
                    /*
                    // Reset speed if we were already moving in the opposite direction!
                    if (previousDirection == CharacterInput.Direction.Left)
                        Speed.Reset();*/
                    MovementExecution.AddPosition(new Vector2(Speed.GetAscendingValue() * Time.fixedDeltaTime, 0f));
                    return true;
                case CharacterInput.Direction.Left:
                    Character.CurrentState = Character.State.Moving;
                    Character.Rigidbody.velocity = Vector2.zero;
                    /*
                    // Reset speed if we were already moving in the opposite direction!
                    if (previousDirection == CharacterInput.Direction.Right)
                        Speed.Reset();*/
                    MovementExecution.AddPosition(new Vector2(-Speed.GetAscendingValue() * Time.fixedDeltaTime, 0f));
                    return true;
                default:
                    Character.CurrentState = Character.State.Idle;
                    return false;
            }
        }

    }
}
