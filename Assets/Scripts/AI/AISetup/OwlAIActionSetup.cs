using Platformer2DStarterKit.AI;

public class OwlAIActionSetup : AIActionSetup {
    public FlyAIAction FlyAIAction;
    public AttackAIAction AttackAIAction;
    public SetAnimationAIAction SetAnimationAIAction;

    protected override void Setup(ICharacter character) {
        character.ActionList.ClearActions();

        ComboAIAction comboAIAction = new ComboAIAction {
            Action = AttackAIAction,
            ActionList = new AIActionList(character, character.ActionList.PoolerRepository),
            ExecuteAll = false
        };
        comboAIAction.ActionList.AddAction(new SetGravityScaleAIAction {
            SetValue = 0f,
            OffValue = 1f
        });
        character.ActionList.AddAction(comboAIAction);
        character.ActionList.AddAction(FlyAIAction);
        character.ActionList.AddAction(FlyAIAction.PatrolAIAction);
        character.ActionList.AddAction(SetAnimationAIAction);
    }

}
