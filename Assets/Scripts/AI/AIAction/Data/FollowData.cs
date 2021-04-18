using UnityEngine;
using Platformer2DStarterKit.AI;
using Platformer2DStarterKit.Utility;

public class FollowData {
    private Vector2 lastPosition;
    public Vector2 Position => lastPosition;
    private readonly Timer timer = new Timer();

    public FollowData(ICharacter character) {
        lastPosition = character.Rigidbody.position;
    }

    public void SetPosition(Vector2 position) {
        lastPosition = position;
        timer.SetTime(4f);
    }

    public bool IsOn() {
        return !timer.IsOver;
    }

    public void ExecuteTime() => timer.Execute(Time.fixedDeltaTime);

}
