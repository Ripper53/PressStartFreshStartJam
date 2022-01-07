using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class DeactivateOnFinishAnimation : MonoBehaviour {
        public GameObject GameObject;
        public FrameAnimator FrameAnimator;

        private void Update() {
            if (FrameAnimator.IsFinished)
                GameObject.SetActive(false);
        }

    }
}
