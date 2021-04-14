using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.AI;

[System.Serializable]
public class CharacterInputFollowAIAction : IAIAction, IAIAction.ICancelable {
    public GetColliders GetColliders;

    public void Cancel(IAIAction.ICancelable.Token token) {
        token.Source.Character.Input.Dir = CharacterInput.Direction.None;
    }

    public bool Execute(AIActionList.Token token) {
        if (GetColliders.Get(out Collider2D col)) {
            float dir = col.transform.position.x - token.Source.Position.x;
            if (dir > 0f) {
                token.Source.Wander.MovementAndJumpExecution(token.Source.Wander.RightSide, out token.Source.Character.Input.Dir, ref token.Source.Character.Input.JumpRequest);
            } else {
                token.Source.Wander.MovementAndJumpExecution(token.Source.Wander.LeftSide, out token.Source.Character.Input.Dir, ref token.Source.Character.Input.JumpRequest);
            }
            return true;
        }
        return false;
    }

}
