using UnityEngine;
using Platformer2DStarterKit.UI;

namespace Platformer2DStarterKit.Utility {
    public class DisableAnimationOnFinish : MonoBehaviour {
        public AnimationUI AnimationUI;

        private void LateUpdate() {
            if (!AnimationUI.IsFinished) return;
            AnimationUI.End();
            AnimationUI.enabled = false;
            enabled = false;
        }

    }
}
