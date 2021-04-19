using UnityEngine;

namespace Platformer2DStarterKit.AI {
    [System.Serializable]
    public class SpiderAIAction : IAIAction, IAIAction.IConditional, IAIAction.IStartable, IAIAction.ICancelable {
        public GetColliders FollowGetColliders;
        public Vector2 FollowOffset;
        public Vector2 WallOffset;
        public SpriteAnimationBase Animation;

        public FollowData FollowData;

        private bool wallOffsetSet;
        private Vector2 wallOffset;
        private float speed, angle;

        private enum Direction { UP, RIGHT, DOWN, LEFT };
        private Direction currentDir = Direction.DOWN;

        public bool Condition(IAIAction.IConditional.Token token) {
            if (token.Source.Character.GroundCheck.Evaluate()) {
                if (FollowGetColliders.Get(out Collider2D col))
                    FollowData.SetPosition(col.transform.position);
                else if (!FollowData.IsOn() || Vector2.Distance(FollowData.Position, token.Source.Rigidbody.position) < FollowOffset.x)
                    return false;
                Vector2 dir = FollowData.Position - token.Source.Rigidbody.position;
                if (Mathf.Abs(dir.y) < FollowOffset.y)
                    return false;
                bool belowY = dir.y < 0f;
                speed = belowY ? -token.Source.Speed.GetAscendingValue() : token.Source.Speed.GetAscendingValue();
                if (dir.x > 0f) {
                    // RIGHT
                    token.Source.SpriteRenderer.flipX = false;
                    if (SetRightSide(token, belowY))
                        return true;
                } else {
                    // LEFT
                    token.Source.SpriteRenderer.flipX = true;
                    if (SetLeftSide(token, belowY))
                        return true;
                }
                if (currentDir != Direction.DOWN)
                    return true;
            }
            return false;
        }
        private bool SetRightSide(IAIAction.IConditional.Token token, bool belowY) {
            if (token.Source.Wander.RightSide.WallCheck.Evaluate()) {
                switch (currentDir) {
                    case Direction.UP:
                        currentDir = Direction.LEFT;
                        angle = 270f;
                        break;
                    case Direction.RIGHT:
                        currentDir = Direction.UP;
                        angle = 180f;
                        break;
                    case Direction.DOWN:
                        if (belowY) {
                            currentDir = Direction.LEFT;
                            angle = 270f;
                            wallOffset = new Vector2(0f, -WallOffset.y);
                            wallOffsetSet = true;
                            return true;
                        } else {
                            currentDir = Direction.RIGHT;
                            angle = 90f;
                        }
                        break;
                    default:
                        currentDir = Direction.DOWN;
                        angle = 0f;
                        return false;
                }
                wallOffset = WallOffset;
                wallOffsetSet = true;
                return true;
            }
            return false;
        }
        private bool SetLeftSide(IAIAction.IConditional.Token token, bool belowY) {
            if (token.Source.Wander.LeftSide.WallCheck.Evaluate()) {
                switch (currentDir) {
                    case Direction.UP:
                        currentDir = Direction.RIGHT;
                        angle = -270f;
                        break;
                    case Direction.LEFT:
                        currentDir = Direction.UP;
                        angle = -180f;
                        break;
                    case Direction.DOWN:
                        if (belowY) {
                            currentDir = Direction.RIGHT;
                            angle = -270f;
                            wallOffset = new Vector2(0f, -WallOffset.y);
                            wallOffsetSet = true;
                            return true;
                        } else {
                            currentDir = Direction.LEFT;
                            angle = -90f;
                        }
                        break;
                    default:
                        currentDir = Direction.DOWN;
                        angle = 0f;
                        return false;
                }
                wallOffset = new Vector2(-WallOffset.x, WallOffset.y);
                wallOffsetSet = true;
                return true;
            }
            return false;
        }

        public void Start(IAIAction.IStartable.Token token) {
            token.Source.Character.Input.Dir = CharacterInput.Direction.None;
            token.Source.Movement.enabled = false;
            token.Source.Jump.enabled = false;
            token.Source.Animator.SetAnimation(Animation);
            token.Source.Rigidbody.gravityScale = 0f;
        }

        public void Cancel(IAIAction.ICancelable.Token token) {
            token.Source.Rigidbody.gravityScale = 1f;
            token.Source.Rigidbody.rotation = 0f;
            currentDir = Direction.DOWN;
            token.Source.Movement.enabled = true;
            token.Source.Jump.enabled = true;
        }

        public bool Execute(AIActionList.Token token) {
            if (wallOffsetSet) {
                wallOffsetSet = false;
                token.Source.Rigidbody.position += wallOffset;
            }
            token.Source.Rigidbody.rotation = angle;
            token.Source.MovementExecution.AddPosition(new Vector2(0f, speed * Time.fixedDeltaTime));
            return true;
        }

    }
}
