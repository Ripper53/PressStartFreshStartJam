using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.AI;
using Platformer2DStarterKit.Utility;

[System.Serializable]
public class FlyAIAction : IAIAction, IAIAction.IStartable, IAIAction.ICancelable {
    public CharacterAnimator CharacterAnimator;

    public SpriteAnimationBase FlyingAnimation;
    public float Speed;
    public float Amplitude;

    public GetColliders FollowGetColliders;
    public GetColliders AttackGetColliders;
    public Check HoverGroundBelowCheck;

    public PatrolAIAction PatrolAIAction;

    public void Start(IAIAction.IStartable.Token token) {
        token.Source.Movement.enabled = false;
        token.Source.Jump.enabled = false;
        CharacterAnimator.enabled = false;
        token.Source.Rigidbody.gravityScale = 0f;
        token.Source.Animator.SetAnimation(FlyingAnimation);
        PatrolAIAction.SetTime();
    }

    public void Cancel(IAIAction.ICancelable.Token token) {
        token.Source.Character.Input.Dir = CharacterInput.Direction.None;
        token.Source.Rigidbody.gravityScale = 1f;
        token.Source.Movement.enabled = true;
        token.Source.Jump.enabled = true;
        CharacterAnimator.enabled = true;
    }

    public bool Execute(AIActionList.Token token) {
        if (AttackGetColliders.Get(out Collider2D col)) {
            return Target(token, col);
        } else if (FollowGetColliders.Get(out col)) {
            return Fly(token, col);
        } else {
            return Hover(token);
        }
    }

    private float FunctionY(float x) {
        return Mathf.Sin(x);
    }

    private float prevFuncY = 0f, x = 0f;
    private bool Fly(AIActionList.Token token, Collider2D col) {
        Vector2 move = new Vector2(Speed * Time.fixedDeltaTime, 0f);
        x = (x + move.x) % (2f * Mathf.PI);
        float funcY = FunctionY(x);
        move.y = (prevFuncY - funcY) * Amplitude;
        prevFuncY = funcY;

        Vector2 dir = ((Vector2)col.transform.position - token.Source.Rigidbody.position).normalized;
        FaceDirection(token, dir);
        float angle = Mathf.Atan2(dir.y, dir.x);
        float sin = Mathf.Sin(angle), cos = Mathf.Cos(angle);
        float newX = (move.x * cos) - (move.y * sin); // We need to use old X for Y, that is why we store the new X value!
        move.y = (move.x * sin) + (move.y * cos);
        move.x = newX;

        token.Source.MovementExecution.AddPosition(move);
        return true;
    }

    private bool Target(AIActionList.Token token, Collider2D targetCol) {
        Vector2 dir = (Vector2)targetCol.transform.position - token.Source.Rigidbody.position;
        FaceDirection(token, dir);
        token.Source.MovementExecution.AddPosition(dir.normalized * Speed * Time.fixedDeltaTime);
        return true;
    }

    private static void FaceDirection(AIActionList.Token token, Vector2 dir) {
        token.Source.Character.Input.Dir = dir.x < 0f ? CharacterInput.Direction.Left : CharacterInput.Direction.Right;
    }

    private bool Hover(AIActionList.Token token) {
        if (token.Source.Character.GroundCheck.Evaluate())
            return false;
        if (HoverGroundBelowCheck.Evaluate())
            token.Source.MovementExecution.AddPosition(new Vector2(0f, -Speed * Time.fixedDeltaTime));
        return true;
    }

}
