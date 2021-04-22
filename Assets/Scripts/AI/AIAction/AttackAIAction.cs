using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;
using Platformer2DStarterKit.AI;

[System.Serializable]
public class AttackAIAction : IAIAction, IAIAction.IConditional, IAIAction.IStartable, IAIAction.ICancelable {
    public CharacterAnimator CharacterAnimator;
    public SpriteAnimationBase AttackAnimation;
    public float AttackTime;

    public Check AttackCheck;
    public GetColliders AttackGetColliders;
    public float AttackOffsetX;

    private readonly Timer attackTimer = new Timer();

    public bool Condition(IAIAction.IConditional.Token token) {
        if (token.Source.Animator.CurrentSpriteAnimation != AttackAnimation) {
            return AttackCheck.Evaluate();
        } else {
            return !token.Source.Animator.IsFinished;
        }
    }

    private bool toAttack;
    public void Start(IAIAction.IStartable.Token token) {
        CharacterAnimator.enabled = false;
        toAttack = true;
        token.Source.Animator.SetAnimation(AttackAnimation);
        attackTimer.SetTime(AttackTime);
    }

    public void Cancel(IAIAction.ICancelable.Token token) {
        CharacterAnimator.enabled = true;
    }

    public bool Execute(AIActionList.Token token) {
        if (token.Source.SpriteRenderer.flipX) {
            AttackGetColliders.ShapeParameter.Offset.x = -AttackOffsetX;
        } else {
            AttackGetColliders.ShapeParameter.Offset.x = AttackOffsetX;
        }
        if (toAttack && !attackTimer.Execute(Time.fixedDeltaTime)) {
            toAttack = false;
            CharacterDeath.Kill(AttackGetColliders);
        }
        return true;
    }

}
