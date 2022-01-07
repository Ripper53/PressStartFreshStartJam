namespace Platformer2DStarterKit.AI {
    public class ComboAIAction<T> : GroupAIAction, IAIAction.IStartable where T : IAIAction {
        public T Action;
        public bool ExecuteAll = true;

        public override void Reinitialize(IAIAction.IReinitialize.Token token) {
            if (Action is IAIAction.IReinitialize reinitializeAction)
                reinitializeAction.Reinitialize(token);
            base.Reinitialize(token);
        }

        public void Start(IAIAction.IStartable.Token token) {
            if (Action is IAIAction.IStartable startableAction)
                startableAction.Start(token);
        }

        public override void Cancel(IAIAction.ICancelable.Token token) {
            if (Action is IAIAction.ICancelable cancelableAction)
                cancelableAction.Cancel(token);
            base.Cancel(token);
        }

        public override bool Execute(AIActionList.Token source) {
            if (!Action.Execute(source))
                return false;
            if (ExecuteAll)
                ActionList.ExecuteAll();
            else
                ActionList.Execute();
            return true;
        }

    }
}
