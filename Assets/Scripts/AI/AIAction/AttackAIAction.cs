using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;
using Platformer2DStarterKit.AI;

[System.Serializable]
public class AttackAIAction : IAIAction, IAIAction.IStartable {
    public SpriteAnimationBase AttackAnimation;
    public float AttackTime;

    public Check AttackCheck;
    public GetColliders AttackGetColliders;
    public float AttackOffsetX;

    private readonly Timer attackTimer = new Timer();

    public void Start(IAIAction.IStartable.Token token) {
        token.Source.Animator.SetAnimation(AttackAnimation);
        attackTimer.SetTime(AttackTime);
    }

    public bool Execute(AIActionList.Token token) {
        if (token.Source.Animator.CurrentSpriteAnimation == AttackAnimation && token.Source.Animator.IsFinished)
            return false;
        if (attackTimer.Execute(Time.fixedDeltaTime) || AttackCheck.Evaluate()) {
            if (AttackGetColliders.Get(out Collider2D col)) {
                float dir = col.transform.position.x - token.Source.Rigidbody.position.x;
                if (dir > 0f) {
                    token.Source.SpriteRenderer.flipX = false;
                    AttackGetColliders.ShapeParameter.Offset.x = AttackOffsetX;
                } else {
                    token.Source.SpriteRenderer.flipX = true;
                    AttackGetColliders.ShapeParameter.Offset.x = -AttackOffsetX;
                }
                CharacterDeath.Kill(AttackGetColliders);
            }
            return true;
        }
        return false;
    }

}
