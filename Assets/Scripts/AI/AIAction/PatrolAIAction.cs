using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.AI;
using Platformer2DStarterKit.Utility;

[System.Serializable]
public class PatrolAIAction : IAIAction, IAIAction.IConditional, IAIAction.IStartable, IAIAction.ICancelable {
    public float PatrolTime;
    public float PauseTime;
    public float ActionTime;

    private enum State {
        Patrol, Pause
    };
    private State currentState;

    private readonly Timer timer = new Timer();
    private readonly Timer patrolTimer = new Timer();

    private CharacterInput.Direction nextDir;

    public void SetTime() {
        timer.SetTime(ActionTime);
    }

    public bool Condition(IAIAction.IConditional.Token token) {
        return timer.Execute(Time.fixedDeltaTime);
    }

    public void Start(IAIAction.IStartable.Token token) {
        currentState = State.Patrol;
        patrolTimer.SetTime(PatrolTime);
        if (token.Source.SpriteRenderer.flipX) {
            token.Source.Character.Input.Dir = CharacterInput.Direction.Left;
            nextDir = CharacterInput.Direction.Right;
        } else {
            token.Source.Character.Input.Dir = CharacterInput.Direction.Right;
            nextDir = CharacterInput.Direction.Left;
        }
    }

    public void Cancel(IAIAction.ICancelable.Token token) {
        token.Source.Character.Input.Dir = CharacterInput.Direction.None;
    }

    public bool Execute(AIActionList.Token token) {
        if (!patrolTimer.Execute(Time.fixedDeltaTime)) {
            switch (currentState) {
                case State.Patrol:
                    token.Source.Character.Input.Dir = CharacterInput.Direction.None;
                    currentState = State.Pause;
                    patrolTimer.SetTime(PauseTime);
                    break;
                default:
                    nextDir = nextDir == CharacterInput.Direction.Left ? CharacterInput.Direction.Right : CharacterInput.Direction.Left;
                    currentState = State.Patrol;
                    patrolTimer.SetTime(PatrolTime);
                    break;
            }
        } else if (currentState == State.Patrol) {
            if (nextDir == CharacterInput.Direction.Left)
                token.Source.Wander.MovementAndJumpExecution(token.Source.Wander.RightSide, out token.Source.Character.Input.Dir, ref token.Source.Character.Input.JumpRequest);
            else
                token.Source.Wander.MovementAndJumpExecution(token.Source.Wander.LeftSide, out token.Source.Character.Input.Dir, ref token.Source.Character.Input.JumpRequest);
        }
        return true;
    }

}
