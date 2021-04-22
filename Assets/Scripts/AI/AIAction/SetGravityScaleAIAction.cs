using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.AI;

[System.Serializable]
public class SetGravityScaleAIAction : IAIAction, IAIAction.IStartable, IAIAction.ICancelable {
    public CharacterFall CharacterFall;
    public float SetValue, OffValue;

    public void Start(IAIAction.IStartable.Token token) {
        CharacterFall.enabled = false;
        token.Source.Rigidbody.velocity = Vector2.zero;
    }

    public void Cancel(IAIAction.ICancelable.Token token) {
        token.Source.Rigidbody.gravityScale = OffValue;
        CharacterFall.enabled = true;
    }

    public bool Execute(AIActionList.Token token) {
        token.Source.Rigidbody.gravityScale = SetValue;
        return true;
    }

}
