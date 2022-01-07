using UnityEngine;

namespace Platformer2DStarterKit {
    public class CircleParameter : ShapeParameter {
        public float Radius = 1f;

#if UNITY_EDITOR
        protected override void OnDrawGizmosSelected() {
            if (!Transform) return;
            base.OnDrawGizmosSelected();
            Gizmos.DrawWireSphere(Offset, Radius);
        }
#endif

    }
}
