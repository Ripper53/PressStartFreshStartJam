using Platformer2DStarterKit.AI;

public class ExecuteDataAIAction : IAIAction {
    public FollowData FollowData;

    public bool Execute(AIActionList.Token token) {
        FollowData.ExecuteTime();
        return false;
    }

}
