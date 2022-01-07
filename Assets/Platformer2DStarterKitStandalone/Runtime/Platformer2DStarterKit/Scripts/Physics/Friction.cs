using UnityEngine;

namespace Platformer2DStarterKit.Physics {
    public class Friction : MonoBehaviour {
        public Rigidbody2D Rigidbody;
        public Check Check;
        public float Drag;

        private void FixedUpdate() {
            if (Check.Evaluate())
                Rigidbody.drag = Drag;
            else
                Rigidbody.drag = 0f;
        }

    }
}
