using UnityEngine;

namespace Platformer2DStarterKit {
    public class SpriteTileParameter : ShapeParameter {
        public SpriteRenderer SpriteRenderer;
        /// <summary>
        /// Size difference from SpriteRenderer's tile size.
        /// </summary>
        [Tooltip("Size difference from SpriteRenderer's tile size.")]
        public Vector2 SizeOffset;
        /// <summary>
        /// Transform.localScale * (SpriteRenderer.size + SizeOffset)
        /// </summary>
        public Vector2 Scale => Transform.localScale * (SpriteRenderer.size + SizeOffset);
        public float Angle => Transform.eulerAngles.z;

#if UNITY_EDITOR
        protected override void OnDrawGizmosSelected() {
            if (!Transform || !SpriteRenderer) return;
            base.OnDrawGizmosSelected();
            Gizmos.DrawWireCube(Offset, SpriteRenderer.size + SizeOffset);
        }
#endif

    }
}
