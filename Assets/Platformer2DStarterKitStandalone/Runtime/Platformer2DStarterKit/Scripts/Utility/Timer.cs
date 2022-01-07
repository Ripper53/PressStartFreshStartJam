namespace Platformer2DStarterKit.Utility {
    public class Timer {
        /// <summary>
        /// True if timer is 0 or below, otherwise false.
        /// </summary>
        public bool IsOver => Value <= 0f;
        public float Value { get; private set; }
        public void SetTime(float value) {
            Value = value;
        }

        /// <returns>True if timer above 0, otherwise false.</returns>
        public bool Execute(float deltaTime) {
            if (Value > 0f) {
                Value -= deltaTime;
                return true;
            }
            return false;
        }

        public void Reset() => Value = 0f;

    }
}
