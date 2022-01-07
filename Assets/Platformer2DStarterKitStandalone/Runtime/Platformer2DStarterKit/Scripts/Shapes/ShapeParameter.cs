using UnityEngine;

namespace Platformer2DStarterKit {
    /// <summary>
    /// Used when certain parameters of basic shapes are needed for processing.
    /// Ex. Used with Checks and GetColliders.
    /// </summary>
    public abstract class ShapeParameter : MonoBehaviour {
        public Transform Transform;
        public Vector2 Offset;
        /// <summary>
        /// Transform.position + Offset
        /// </summary>
        public Vector2 Position => (Vector2)Transform.position + Offset;

#if UNITY_EDITOR
        protected virtual void OnDrawGizmosSelected() {
            Gizmos.color = Color.green;
            Gizmos.matrix = Transform.localToWorldMatrix;
        }
#endif

    }
}
