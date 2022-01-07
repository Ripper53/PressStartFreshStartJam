namespace Platformer2DStarterKit.AI {
    public abstract class GroupAIAction : IAIAction, IAIAction.IReinitialize, IAIAction.ICancelable {
        public AIActionList ActionList;

        public abstract bool Execute(AIActionList.Token token);

        public virtual void Reinitialize(IAIAction.IReinitialize.Token token) {
            ActionList.ReinitializeActions();
        }

        public virtual void Cancel(IAIAction.ICancelable.Token token) {
            ActionList.CancelAction();
        }

    }
}
