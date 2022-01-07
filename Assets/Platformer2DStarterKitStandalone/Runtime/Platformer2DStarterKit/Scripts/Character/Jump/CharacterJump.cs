using UnityEngine;

namespace Platformer2DStarterKit {
    public class CharacterJump : MonoBehaviour {
        public Character Character;
        public GradientRate Speed;
        /// <summary>
        /// Directional jump force, as if the character were jumping to the right.
        /// Ex. (5, 10) would mean, jump up with a force of 10, and if right is held, jump right with a force of 5, and if left is held, jump left with a force of -5 (velocity will be negative to go left).
        /// </summary>
        [Tooltip("Directional jump force, as if the character were jumping to the right.\n\nEx. (5, 10) would mean, jump up with a force of 10, and if right is held, jump right with a force of 5, and if left is held, jump left with a force of -5 (velocity will be negative to go left).")]
        public Vector2 Force = new Vector2(5f, 10f);
        /// <summary>
        /// The minimum force applied in the X direction no matter the speed value!
        /// </summary>
        [Tooltip("The minimum force applied in the X direction no matter the speed value!")]
        public float MinimumForceX;
        /// <summary>
        /// When beside a wall, and jumping with a lower force than the minimum, what is the force applied in the X direction to get over it?
        /// </summary>
        [Tooltip("When beside a wall, and jumping with a lower force than the minimum, what is the force applied in the X direction to get over it?")]
        public float WallForceX;
        public Check RightWallCheck, LeftWallCheck;
        /// <summary>
        /// Time (in seconds) the character won't be able to jump for after they start jumping.
        /// </summary>
        [Tooltip("Time (in seconds) the character won't be able to jump for after they start jumping.")]
        public float DisableTime = 0.1f;

        private float disableTimer = 0f;

        private float GetJumpX(Check wallCheck) {
            float x = Force.x * (Speed.Value / Speed.Max);
            if (x < MinimumForceX) {
                if (wallCheck.Evaluate())
                    return WallForceX;
                else
                    return MinimumForceX;
            } else if (x < Speed.Value) {
                x = Speed.Value;
            }
            return x;
        }

        private void FixedUpdate() {
            if (disableTimer > 0f) {
                disableTimer -= Time.fixedDeltaTime;
            } else if (Character.CurrentState == Character.State.Jumping) {
                Character.CurrentState = Character.State.Idle;
            } else if (Character.Input.JumpRequest) {
                Character.Input.JumpRequest = false;
                if (Character.CurrentState != Character.State.Stunned && Character.GroundCheck.Evaluate()) {
                    Vector2 directionalForce = new Vector2(0f, Force.y);
                    switch (Character.Input.Dir) {
                        case CharacterInput.Direction.Right:
                            directionalForce.x = GetJumpX(RightWallCheck);
                            break;
                        case CharacterInput.Direction.Left:
                            directionalForce.x = -GetJumpX(LeftWallCheck);
                            break;
                    }
                    Jump(directionalForce);
                }
            }
        }

        public void Jump(Vector2 force) {
            switch (Character.MovementExecution.Rigidbody.bodyType) {
                case RigidbodyType2D.Dynamic:
                    Character.MovementExecution.AddPosition(force * Time.fixedDeltaTime);
                    break;
                default:
                    Character.Rigidbody.velocity = force;
                    break;
            }
            Character.CurrentState = Character.State.Jumping;
            disableTimer = DisableTime;
        }

        public void DirectionalJump(Vector2 force) {
            switch (Character.Input.Dir) {
                case CharacterInput.Direction.None:
                    force = new Vector2(0f, force.y);
                    break;
                case CharacterInput.Direction.Left:
                    force = new Vector2(-force.x, force.y);
                    break;
            }
            Jump(force);
        }

    }
}
