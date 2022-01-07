using UnityEngine;

namespace Platformer2DStarterKit {
    public class GradientRate : MonoBehaviour {
        public float AscendIncrement, DescendIncrement, Max;

        public float Value { get; private set; }

        public float GetAscendingValue() {
            if (Value < Max) {
                Value += AscendIncrement;
                if (Value > Max)
                    Value = Max;
            } else {
                Value -= DescendIncrement;
                if (Value < Max)
                    Value = Max;
            }
            return Value;
        }

        public float GetDescendingValue() {
            Value -= DescendIncrement;
            if (Value < 0f)
                Value = 0f;
            return Value;
        }

        public void Reinitialize() => Value = 0f;

    }
}
