using UnityEngine;

namespace Platformer2DStarterKit.UI {
    public abstract class AnimationUI : MonoBehaviour {
        public abstract bool IsFinished { get; }
        public abstract void End();
    }
}
