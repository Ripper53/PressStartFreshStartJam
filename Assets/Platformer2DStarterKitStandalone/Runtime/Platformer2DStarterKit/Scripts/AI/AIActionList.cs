using System.Collections.Generic;
using Platformer2DStarterKit.Utility;

namespace Platformer2DStarterKit.AI {
    public class AIActionList {
        public readonly ICharacter Source;
        public readonly PoolerRepository PoolerRepository;

        public AIActionList(ICharacter source, PoolerRepository poolerRepository) {
            Source = source;
            PoolerRepository = poolerRepository;
        }

        private readonly List<IAIAction> actions = new List<IAIAction>();
        public IReadOnlyList<IAIAction> Actions => actions;
        private readonly List<IAIAction.IReinitialize> reinitializeActions = new List<IAIAction.IReinitialize>();
        private readonly List<IAIAction.IStartable> startableActions = new List<IAIAction.IStartable>();

        public class Token {
            public readonly ICharacter Source;
            public Token(ICharacter source) {
                Source = source;
            }
        }

        private IAIAction currentAIAction = null;
        private IAIAction.ICancelable cancelableAction = null;
        public void CancelAction() {
            if (cancelableAction == null) return;
            cancelableAction.Cancel(new IAIAction.ICancelable.Token(Source));
            cancelableAction = null;
            currentAIAction = null;
        }
        public bool Execute() {
            Token token = new Token(Source);
            foreach (IAIAction action in Actions) {
                if (ExecuteAction(action, token))
                    return true;
            }
            if (cancelableAction != null) {
                cancelableAction.Cancel(new IAIAction.ICancelable.Token(Source));
                cancelableAction = null;
            }
            currentAIAction = null;
            return false;
        }
        public void ExecuteAll() {
            Token token = new Token(Source);
            foreach (IAIAction action in Actions)
                ExecuteAction(action, token);
        }
        private bool ExecuteAction(IAIAction action, Token token) {
            if (action is IAIAction.IConditional conditional) {
                return ExecuteAction(action, conditional, token);
            } else if (action.Execute(token)) {
                if (cancelableAction != null && cancelableAction != action) {
                    cancelableAction.Cancel(new IAIAction.ICancelable.Token(Source));
                    cancelableAction = null;
                }
                if (action is IAIAction.ICancelable cancelAction)
                    cancelableAction = cancelAction;
                if (currentAIAction != action && action is IAIAction.IStartable startableAction)
                    startableAction.Start(new IAIAction.IStartable.Token(Source));
                currentAIAction = action;
                return true;
            } else if (cancelableAction == action) {
                cancelableAction.Cancel(new IAIAction.ICancelable.Token(Source));
                cancelableAction = null;
            }
            return false;
        }
        private bool ExecuteAction(IAIAction action, IAIAction.IConditional conditional, Token token) {
            if (conditional.Condition(new IAIAction.IConditional.Token(Source))) {
                if (cancelableAction != null && cancelableAction != action) {
                    cancelableAction.Cancel(new IAIAction.ICancelable.Token(Source));
                    cancelableAction = null;
                }
                if (action is IAIAction.ICancelable cancelAction)
                    cancelableAction = cancelAction;
                if (currentAIAction != action && action is IAIAction.IStartable startableAction)
                    startableAction.Start(new IAIAction.IStartable.Token(Source));
                currentAIAction = action;
                if (action.Execute(token))
                    return true;
            } else if (cancelableAction == action) {
                cancelableAction.Cancel(new IAIAction.ICancelable.Token(Source));
                cancelableAction = null;
            }
            return false;
        }

        public void AddAction(IAIAction action) {
            if (action is IAIAction.IInitialize initializeAction)
                initializeAction.Initialize(new IAIAction.IInitialize.Token(Source, PoolerRepository));
            if (action is IAIAction.IReinitialize reinitializeAction)
                reinitializeActions.Add(reinitializeAction);
            if (action is IAIAction.IStartable startableAction)
                startableActions.Add(startableAction);
            actions.Add(action);
        }

        public void RemoveAction(IAIAction action) {
            if (cancelableAction == action) {
                cancelableAction.Cancel(new IAIAction.ICancelable.Token(Source));
                cancelableAction = null;
            }
            if (action is IAIAction.IReinitialize reinitializeAction)
                reinitializeActions.Remove(reinitializeAction);
            if (action is IAIAction.IStartable startableAction)
                startableActions.Remove(startableAction);
            if (action is IAIAction.IRemove removeAction)
                removeAction.Remove();
            actions.Remove(action);
        }

        public void ClearActions() {
            actions.Clear();
        }

        public void ReinitializeActions() {
            CancelAction();
            IAIAction.IReinitialize.Token token = new IAIAction.IReinitialize.Token(Source);
            foreach (IAIAction.IReinitialize action in reinitializeActions)
                action.Reinitialize(token);
        }

    }
}
