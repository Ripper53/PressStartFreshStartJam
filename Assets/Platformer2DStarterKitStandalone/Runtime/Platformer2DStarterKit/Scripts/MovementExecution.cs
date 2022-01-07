using UnityEngine;

namespace Platformer2DStarterKit {
    /// <summary>
    /// Executes the movement provided at the end of the fixed update.
    /// Should be set to execute after default time in Script Execution Order!
    /// </summary>
    public class MovementExecution : MonoBehaviour {
        public Rigidbody2D Rigidbody;

        public Vector2 Movement { get; private set; } = Vector2.zero;
        private bool toMove = false;

        public void AddPosition(Vector2 position) {
            Movement += position;
            toMove = true;
        }

        public void Reinitialize() {
            toMove = false;
            Movement = Vector2.zero;
        }

        private void FixedUpdate() {
            if (!toMove) return;
            toMove = false;
            switch (Rigidbody.bodyType) {
                case RigidbodyType2D.Dynamic:
                    Rigidbody.velocity = Movement / Time.fixedDeltaTime;
                    break;
                default:
                    Rigidbody.MovePosition(Rigidbody.position + Movement);
                    break;
            }
            Movement = Vector2.zero;
        }

    }
}
