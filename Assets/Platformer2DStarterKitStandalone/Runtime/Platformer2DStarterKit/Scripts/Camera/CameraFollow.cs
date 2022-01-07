using UnityEngine;

namespace Platformer2DStarterKit {
    /// <summary>
    /// Follows target in 2D space.
    /// </summary>
    public class CameraFollow : MonoBehaviour {
        public Transform Transform;
        public Transform Target;
        public Vector2 Offset;

        public float FollowTime = 5f;

        private Vector2 vel;

        private void OnEnable() {
            vel = Vector2.zero;
        }

        private void LateUpdate() {
            if (!Target) return;
            Vector2 pos = Vector2.SmoothDamp(Transform.position, (Vector2)Target.position + Offset, ref vel, FollowTime);
            Transform.position = new Vector3(pos.x, pos.y, Transform.position.z);
        }

    }
}
