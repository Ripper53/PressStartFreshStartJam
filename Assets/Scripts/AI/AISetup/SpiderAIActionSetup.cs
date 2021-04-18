using Platformer2DStarterKit.AI;

public class SpiderAIActionSetup : AIActionSetup {
    public CharacterInputFollowAIAction CharacterInputFollowAIAction;
    public SpiderAIAction SpiderAIAction;

    protected override void Setup(ICharacter character) {
        character.ActionList.ClearActions();

        FollowData followData = new FollowData(character);
        SpiderAIAction.FollowData = followData;
        CharacterInputFollowAIAction.FollowData = followData;

        character.ActionList.AddAction(new ExecuteDataAIAction {
            FollowData = followData
        });
        character.ActionList.AddAction(SpiderAIAction);
        character.ActionList.AddAction(CharacterInputFollowAIAction);
    }

}
