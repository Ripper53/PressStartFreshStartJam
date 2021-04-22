using Platformer2DStarterKit.AI;

public class BuddhaHeadAIActionSetup : AIActionSetup {
    public AttackAIAction AttackAIAction;
    public CharacterInputFollowAIAction CharacterInputFollowAIAction;

    protected override void Setup(ICharacter character) {
        character.ActionList.ClearActions();

        FollowData followData = new FollowData(character);
        CharacterInputFollowAIAction.FollowData = followData;

        character.ActionList.AddAction(AttackAIAction);
        character.ActionList.AddAction(CharacterInputFollowAIAction);
    }

}
