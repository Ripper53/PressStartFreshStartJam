using Platformer2DStarterKit.AI;

public class BuddhaHeadAIActionSetup : AIActionSetup {
    public CharacterInputFollowAIAction CharacterInputFollowAIAction;

    protected override void Setup(ICharacter character) {
        character.ActionList.ClearActions();

        FollowData followData = new FollowData(character);
        CharacterInputFollowAIAction.FollowData = followData;

        character.ActionList.AddAction(CharacterInputFollowAIAction);
    }

}
