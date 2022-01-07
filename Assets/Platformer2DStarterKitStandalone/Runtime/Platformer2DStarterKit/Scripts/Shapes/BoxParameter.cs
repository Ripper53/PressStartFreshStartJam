using UnityEngine;

namespace Platformer2DStarterKit {
    public class BoxParameter : ShapeParameter {
        public Vector2 Size = new Vector2(1f, 1f);
        /// <summary>
        /// Transform.localScale * Size
        /// </summary>
        public Vector2 Scale => Transform.localScale * Size;
        public float Angle => Transform.eulerAngles.z;

#if UNITY_EDITOR
        protected override void OnDrawGizmosSelected() {
            if (!Transform) return;
            base.OnDrawGizmosSelected();
            Gizmos.DrawWireCube(Offset, Size);
        }
#endif

    }
}
