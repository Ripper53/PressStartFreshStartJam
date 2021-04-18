using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.AI;

[System.Serializable]
public class CharacterInputFollowAIAction : IAIAction, IAIAction.ICancelable {
    public GetColliders GetColliders;
    public float FollowOffset;

    public FollowData FollowData;

    public void Cancel(IAIAction.ICancelable.Token token) {
        token.Source.Character.Input.Dir = CharacterInput.Direction.None;
    }

    public bool Execute(AIActionList.Token token) {
        if (GetColliders.Get(out Collider2D col)) {
            FollowData.SetPosition(col.transform.position);
            return Follow(token);
        } else if (FollowData.IsOn() && Mathf.Abs(token.Source.Rigidbody.position.x - FollowData.Position.x) > FollowOffset) {
            return Follow(token);
        }
        return false;
    }

    private bool Follow(AIActionList.Token token) {
        float dir = FollowData.Position.x - token.Source.Position.x;
        if (dir > 0f) {
            return token.Source.Wander.MovementAndJumpExecution(token.Source.Wander.RightSide, out token.Source.Character.Input.Dir, ref token.Source.Character.Input.JumpRequest);
        } else {
            return token.Source.Wander.MovementAndJumpExecution(token.Source.Wander.LeftSide, out token.Source.Character.Input.Dir, ref token.Source.Character.Input.JumpRequest);
        }
    }

}
