using UnityEngine;
using Platformer2DStarterKit.AI;

public class BuddhaAIActionSetup : AIActionSetup {
    public SpriteRenderer LaserPrefab;
    public BuddhaAIAction BuddhaAIAction;

    protected override void Setup(ICharacter character) {
        character.ActionList.ClearActions();

        InitializeHand(BuddhaAIAction.RightHand);
        InitializeHand(BuddhaAIAction.LeftHand);

        character.ActionList.AddAction(BuddhaAIAction);
    }

    private void InitializeHand(BuddhaAIAction.Hand hand) {
        SpriteRenderer rightLaser = Instantiate(LaserPrefab);
        hand.Action = BuddhaAIAction;
        hand.LaserGameObject = rightLaser.gameObject;
        hand.LaserTransform = rightLaser.transform;
        hand.LaserSpriteRenderer = rightLaser;
    }

}
