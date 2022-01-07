using UnityEngine;

namespace Platformer2DStarterKit {
    public class SightCheck : LayerCheck {
        public GetColliders GetColliders;
        public Transform Origin;
        public override ShapeParameter ShapeParameter => GetColliders.ShapeParameter;

        public override bool Evaluate() {
            foreach (Collider2D col in GetColliders.Get()) {
                if (Cast(col))
                    return true;
            }
            return false;
        }

        private bool Cast(Collider2D col) {
            return !Physics2D.Raycast(Origin.position, col.transform.position - Origin.position, Vector2.Distance(col.transform.position, Origin.position), LayerMask).collider;
        }

    }
}
