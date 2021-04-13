using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2DStarterKit.AI;

public class OwlAIActionSetup : AIActionSetup {
    public FlyAIAction FlyAIAction;
    public SetAnimationAIAction SetAnimationAIAction;

    protected override void Setup(ICharacter character) {
        character.ActionList.ClearActions();

        character.ActionList.AddAction(FlyAIAction);
        character.ActionList.AddAction(FlyAIAction.PatrolAIAction);
        character.ActionList.AddAction(SetAnimationAIAction);
    }

}
