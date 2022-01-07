using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public abstract class LoadScene : MonoBehaviour {
        protected string toLoadName;

        public void Load(string name) {
            if (enabled) return;
            toLoadName = name;
            enabled = true;
        }

    }
}
