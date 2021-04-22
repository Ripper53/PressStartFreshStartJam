using Platformer2DStarterKit.AI;

public class OwlAIActionSetup : AIActionSetup {
    public AttackAIAction AttackAIAction;
    public SetGravityScaleAIAction SetGravityScaleAIAction;
    public FlyAIAction FlyAIAction;
    public SetAnimationAIAction SetAnimationAIAction;

    protected override void Setup(ICharacter character) {
        character.ActionList.ClearActions();

        FollowData followData = new FollowData(character);
        FlyAIAction.FollowData = followData;

        ConditionalComboAIAction<AttackAIAction> attackComboAIAction = new ConditionalComboAIAction<AttackAIAction> {
            Action = AttackAIAction,
            ActionList = new AIActionList(character, character.ActionList.PoolerRepository),
            ExecuteAll = false
        };
        attackComboAIAction.ActionList.AddAction(SetGravityScaleAIAction);

        ConditionalComboAIAction<FlyAIAction> flyComboAIAction = new ConditionalComboAIAction<FlyAIAction> {
            Action = FlyAIAction,
            ActionList = new AIActionList(character, character.ActionList.PoolerRepository),
            ExecuteAll = false
        };
        flyComboAIAction.ActionList.AddAction(SetGravityScaleAIAction);

        character.ActionList.AddAction(new ExecuteDataAIAction {
            FollowData = followData
        });
        character.ActionList.AddAction(attackComboAIAction);
        character.ActionList.AddAction(flyComboAIAction);
        character.ActionList.AddAction(FlyAIAction.PatrolAIAction);
        character.ActionList.AddAction(SetAnimationAIAction);
    }

}
