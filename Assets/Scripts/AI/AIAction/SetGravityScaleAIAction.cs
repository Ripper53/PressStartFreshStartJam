using Platformer2DStarterKit.AI;

public class SetGravityScaleAIAction : IAIAction, IAIAction.ICancelable {
    public float SetValue, OffValue;

    public void Cancel(IAIAction.ICancelable.Token token) {
        token.Source.Rigidbody.gravityScale = OffValue;
    }

    public bool Execute(AIActionList.Token token) {
        token.Source.Rigidbody.gravityScale = SetValue;
        return true;
    }

}
