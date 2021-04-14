using Platformer2DStarterKit.AI;

public class CatAIActionSetup : AIActionSetup {
    public AttackAIAction AttackAIAction;
    public CharacterInputFollowAIAction CharacterInputFollowAIAction;
    public SetAnimationAIAction SetAnimationAIAction;

    protected override void Setup(ICharacter character) {
        character.ActionList.ClearActions();

        character.ActionList.AddAction(AttackAIAction);
        character.ActionList.AddAction(CharacterInputFollowAIAction);
        character.ActionList.AddAction(SetAnimationAIAction);
    }

}
