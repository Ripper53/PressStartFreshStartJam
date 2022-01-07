using UnityEngine;

namespace Platformer2DStarterKit.AI {
    [System.Serializable]
    public class WanderAIAction : IAIAction, IAIAction.IReinitialize {
        [Header("Random Movements")]
        public float MinNewDirectionTime = 2;
        public float MaxNewDirectionTime = 8;
        public float MinMoveTime = 2, MaxMoveTime = 4;
        public RightSideChecks RightSide;
        public LeftSideChecks LeftSide;

        private float directionTimer = 0f, moveTimer = 0f;
        private CharacterInput.Direction direction = CharacterInput.Direction.None;
        private SideChecks currentChecks;

        public void Reinitialize(IAIAction.IReinitialize.Token token) {
            directionTimer = 0f;
            moveTimer = 0f;
        }

        public bool Execute(AIActionList.Token token) {
            if (moveTimer > 0f) {
                moveTimer -= Time.fixedDeltaTime;
                if (StrictMovementCheck(currentChecks)) {
                    switch (direction) {
                        case CharacterInput.Direction.Right:
                            MovementAndJumpExecution(RightSide, out token.Source.Character.Input.Dir, ref token.Source.Character.Input.JumpRequest);
                            break;
                        default:
                            MovementAndJumpExecution(LeftSide, out token.Source.Character.Input.Dir, ref token.Source.Character.Input.JumpRequest);
                            break;
                    }
                    if (moveTimer <= 0f)
                        direction = CharacterInput.Direction.None;
                } else {
                    moveTimer = 0f;
                    direction = CharacterInput.Direction.None;
                }
                return true;
            } else if (directionTimer > 0f) {
                directionTimer -= Time.fixedDeltaTime;
                if (directionTimer <= 0f) {
                    SetMove(
                        Random.Range(MinMoveTime, MaxMoveTime),
                        Random.Range(0, 2) == 0 ?
                        CheckMovementDirection(RightSide, LeftSide, CharacterInput.Direction.Right, CharacterInput.Direction.Left) :
                        CheckMovementDirection(LeftSide, RightSide, CharacterInput.Direction.Left, CharacterInput.Direction.Right)
                    );
                }
                return false;
            } else {
                directionTimer = Random.Range(MinNewDirectionTime, MaxNewDirectionTime);
                token.Source.Character.Input.Dir = CharacterInput.Direction.None;
                return false;
            }
        }

        private void SetMove(float moveTime, CharacterInput.Direction direction) {
            directionTimer = 0f;
            moveTimer = moveTime;
            this.direction = direction;
            switch (this.direction) {
                case CharacterInput.Direction.Right:
                    currentChecks = RightSide;
                    return;
                default:
                    currentChecks = LeftSide;
                    return;
            }
        }

        /// <summary>
        /// If there is ground ahead or below, move to it.
        /// Otherwise, if there is ground above or across, jump to it.
        /// </summary>
        public bool MovementAndJumpExecution(SideChecks checks, out CharacterInput.Direction dir, ref bool jumpRequest, float dirY = 1f) {
            bool groundCheck = checks.GroundCheck.Evaluate();
            if ((groundCheck || checks.FallCheck.Evaluate()) && !checks.WallCheck.Evaluate()) {
                dir = checks.Direction;
                if (dirY > 0f && !groundCheck && checks.JumpAboveCheck.Evaluate() && !checks.FreeGroundAboveCheck.Evaluate()) {
                    jumpRequest = true;
                }
            } else if ((checks.JumpAboveCheck.Evaluate() && !checks.FreeGroundAboveCheck.Evaluate()) || (checks.JumpAcrossCheck.Evaluate() && !checks.FreeGroundAcrossCheck.Evaluate())) {
                dir = checks.Direction;
                jumpRequest = true;
            } else {
                dir = CharacterInput.Direction.None;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Make sure there is ground in the direction we want to move, and there is no wall in the way.
        /// If there is, go the other direction.
        /// If the other direction is also blocked, don't move at all.
        /// </summary>
        private static CharacterInput.Direction CheckMovementDirection(SideChecks checks, SideChecks oppositeChecks, CharacterInput.Direction dir, CharacterInput.Direction oppositeDir) {
            if (MovementCheck(checks)) {
                return dir;
            } else if (MovementCheck(oppositeChecks)) {
                return oppositeDir;
            }
            return CharacterInput.Direction.None;
        }
        /// <summary>
        /// There is no wall ahead, and there is ground ahead or below which can be fallen upon.
        /// </summary>
        private static bool MovementCheck(SideChecks checks) {
            return StrictMovementCheck(checks) && (checks.GroundCheck.Evaluate() || checks.FallCheck.Evaluate());
        }
        /// <summary>
        /// There is no wall ahead, or there is ground above!
        /// </summary>
        public static bool StrictMovementCheck(SideChecks checks) {
            return !checks.WallCheck.Evaluate() || !checks.FreeGroundAboveCheck.Evaluate();
        }

    }
}
