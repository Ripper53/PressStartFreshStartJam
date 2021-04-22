using Platformer2DStarterKit.AI;

public class SpiderAIActionSetup : AIActionSetup {
    public AttackAIAction AttackAIAction;
    public SpiderAIAction SpiderAIAction;
    public CharacterInputFollowAIAction CharacterInputFollowAIAction;
    public SetAnimationAIAction SetAnimationAIAction;

    protected override void Setup(ICharacter character) {
        character.ActionList.ClearActions();

        FollowData followData = new FollowData(character);
        SpiderAIAction.FollowData = followData;
        CharacterInputFollowAIAction.FollowData = followData;

        character.ActionList.AddAction(new ExecuteDataAIAction {
            FollowData = followData
        });
        character.ActionList.AddAction(AttackAIAction);
        character.ActionList.AddAction(SpiderAIAction);
        character.ActionList.AddAction(CharacterInputFollowAIAction);
        character.ActionList.AddAction(SetAnimationAIAction);
    }

}
