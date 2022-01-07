using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit.UI {
    public abstract class FadeUI : AnimationUI {
        public float Time;
        [Range(0f, 1f)]
        public float Alpha;

        public abstract float CurrentAlpha { get; set; }
        public override bool IsFinished => ApproximatelyEquals(CurrentAlpha, Alpha);

        public override void End() {
            CurrentAlpha = Alpha;
        }

        public static bool ApproximatelyEquals(float value1, float value2, float acceptableDifference = 0.01f) {
            return Mathf.Abs(value1 - value2) < acceptableDifference;
        }

        private float vel;

        private void OnEnable() {
            vel = 0f;
        }

        private void Update() {
            CurrentAlpha = Fade(CurrentAlpha, Alpha, ref vel, Time);
        }

        public static float Fade(float alpha, float target, ref float vel, float time) {
            return Mathf.SmoothDamp(alpha, target, ref vel, time);
        }

    }
}
