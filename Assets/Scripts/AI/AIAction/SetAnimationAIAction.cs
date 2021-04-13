using Platformer2DStarterKit;
using Platformer2DStarterKit.AI;

[System.Serializable]
public class SetAnimationAIAction : IAIAction {
    public SpriteAnimationBase Animation;

    public bool Execute(AIActionList.Token token) {
        if (token.Source.Animator.CurrentSpriteAnimation != Animation)
            token.Source.Animator.SetAnimation(Animation);
        return false;
    }

}
