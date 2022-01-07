using UnityEngine;

namespace Platformer2DStarterKit.Physics {
    /// <summary>
    /// Moves a Rigidbody towards a target for a certain time, then moves onto the next target until the last target, then repeats.
    /// </summary>
    public abstract class MoveRigidbody : MonoBehaviour {
        public Rigidbody2D Rigidbody;
        public Target[] Targets;

        private int currentTargetIndex = -1;

        [System.Serializable]
        public class Target {
            public Vector2 Position;
            public float Speed;
            public float Time;
        }

        private float timer = 0f;

        private void FixedUpdate() {
            if (timer > 0f) {
                timer -= Time.fixedDeltaTime;
            } else {
                currentTargetIndex++;
                if (currentTargetIndex >= Targets.Length)
                    currentTargetIndex = 0;
                timer = Targets[currentTargetIndex].Time;
            }
            MoveToTarget(Targets[currentTargetIndex]);
        }

        protected abstract void MoveToTarget(Target target);

    }
}
