namespace Platformer2DStarterKit.AI {
    public class ConditionalComboAIAction<T> : ComboAIAction<T>, IAIAction.IConditional where T : IAIAction, IAIAction.IConditional {

        public bool Condition(IAIAction.IConditional.Token token) {
            return Action.Condition(token);
        }

    }
}
