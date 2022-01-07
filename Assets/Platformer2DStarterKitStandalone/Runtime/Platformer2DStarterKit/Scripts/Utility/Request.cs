namespace Platformer2DStarterKit {
    public class Request {
        public bool Value { get; private set; } = false;
        /// <summary>
        /// Change value to true, causing the check to return true.
        /// </summary>
        public void Call() => Value = true;
        /// <summary>
        /// Checks if a request was sent, and if it was, it resets it and returns true.
        /// </summary>
        /// <returns>True if request was called, otherwise false.</returns>
        public bool Check() {
            if (Value) {
                Value = false;
                return true;
            }
            return false;
        }
    }
}
