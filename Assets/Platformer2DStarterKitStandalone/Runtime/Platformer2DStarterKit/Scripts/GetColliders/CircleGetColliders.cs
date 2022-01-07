using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit {
    /// <summary>
    /// Gets colliders contained within a circle.
    /// </summary>
    public class CircleGetColliders : LayerGetColliders {
        public CircleParameter CircleParameter;
        public override ShapeParameter ShapeParameter => CircleParameter;

        public override IEnumerable<Collider2D> Get() {
            return Physics2D.OverlapCircleAll(CircleParameter.Position, CircleParameter.Radius, LayerMask);
        }

        public override bool Get(out Collider2D collider) {
            collider = Physics2D.OverlapCircle(CircleParameter.Position, CircleParameter.Radius, LayerMask);
            if (collider)
                return true;
            return false;
        }

    }
}
