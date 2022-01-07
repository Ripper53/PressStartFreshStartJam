using UnityEngine;

namespace Platformer2DStarterKit {
    public class CharacterFall : MonoBehaviour {
        public Rigidbody2D Rigidbody;
        public float FallForce;

        private void FixedUpdate() {
            if (Rigidbody.velocity.y < 0f)
                Rigidbody.velocity += new Vector2(0f, FallForce);
        }

    }
}
