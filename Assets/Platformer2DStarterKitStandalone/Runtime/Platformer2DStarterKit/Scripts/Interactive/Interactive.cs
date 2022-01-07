using UnityEngine;

namespace Platformer2DStarterKit {
    public abstract class Interactive : MonoBehaviour {
        public Check Check;

        public readonly Request Request = new Request();

        private void FixedUpdate() {
            if (Request.Check() && Check.Evaluate()) {
                Execute();
            }
        }

        public abstract void Execute();

    }
}
