using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit {
    public class SightGetColliders : LayerGetColliders {
        public GetColliders GetColliders;
        public Transform Origin;
        public override ShapeParameter ShapeParameter => GetColliders.ShapeParameter;

        public override IEnumerable<Collider2D> Get() {
            foreach (Collider2D col in GetColliders.Get()) {
                if (Cast(col))
                    yield return col;
            }
        }

        public override bool Get(out Collider2D collider) {
            if (GetColliders.Get(out collider) && Cast(collider))
                return true;
            collider = null;
            return false;
        }

        private bool Cast(Collider2D col) {
            return !Physics2D.Raycast(Origin.position, col.transform.position - Origin.position, Vector2.Distance(col.transform.position, Origin.position), LayerMask).collider;
        }

    }
}
