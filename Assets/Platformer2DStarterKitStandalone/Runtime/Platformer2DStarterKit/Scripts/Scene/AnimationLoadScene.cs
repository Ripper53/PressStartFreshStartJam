using UnityEngine.SceneManagement;
using Platformer2DStarterKit.UI;

namespace Platformer2DStarterKit.Utility {
    public class AnimationLoadScene : LoadScene {
        public AnimationUI AnimationUI;

        private void OnEnable() {
            AnimationUI.enabled = true;
        }

        private void Update() {
            if (AnimationUI.IsFinished) {
                SceneManager.LoadScene(toLoadName);
                enabled = false;
            }
        }
    }
}
