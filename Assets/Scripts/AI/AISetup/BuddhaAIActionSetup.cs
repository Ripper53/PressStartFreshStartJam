using UnityEngine;
using Platformer2DStarterKit.AI;

public class BuddhaAIActionSetup : AIActionSetup {
    public BuddhaScene BuddhaScene;
    public SpriteRenderer LaserPrefab;
    public BuddhaAIAction BuddhaAIAction;

    protected override void Setup(ICharacter character) {
        BuddhaScene.BuddhaAIAction = BuddhaAIAction;

        character.ActionList.ClearActions();

        InitializeHand(BuddhaAIAction.RightHand);
        InitializeHand(BuddhaAIAction.LeftHand);

        character.ActionList.AddAction(BuddhaAIAction);
    }

    private void InitializeHand(BuddhaAIAction.Hand hand) {
        SpriteRenderer laser = Instantiate(LaserPrefab);
        laser.GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
        hand.Action = BuddhaAIAction;
        hand.LaserGameObject = laser.gameObject;
        hand.LaserTransform = laser.transform;
        hand.LaserSpriteRenderer = laser;
    }

}
