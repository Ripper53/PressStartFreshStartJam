using UnityEngine;

namespace Platformer2DStarterKit {
    /// <summary>
    /// Good for constraining the max velocity at which the character drops!
    /// Allows for heavy objects with a lower gravity scale to feel heavier than the character.
    /// Make sure to put Script Execution Order after the default time!
    /// </summary>
    public class ConstraintVelocityY : MonoBehaviour {
        public Rigidbody2D Rigidbody;
        public float MinVelocityY;

        private void FixedUpdate() {
            Vector2 vel = Rigidbody.velocity;
            if (vel.y < MinVelocityY) {
                vel.y = MinVelocityY;
                Rigidbody.velocity = vel;
            }
        }

    }
}
