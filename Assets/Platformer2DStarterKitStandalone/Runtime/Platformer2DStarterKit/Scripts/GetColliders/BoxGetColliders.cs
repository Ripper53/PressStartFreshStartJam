using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit {
    /// <summary>
    /// Gets colliders contained within a box.
    /// </summary>
    public class BoxGetColliders : LayerGetColliders {
        public BoxParameter BoxParameter;
        public override ShapeParameter ShapeParameter => BoxParameter;

        public override IEnumerable<Collider2D> Get() {
            return Physics2D.OverlapBoxAll(BoxParameter.Position, BoxParameter.Scale, BoxParameter.Angle, LayerMask);
        }

        public override bool Get(out Collider2D collider) {
            collider = Physics2D.OverlapBox(BoxParameter.Position, BoxParameter.Scale, BoxParameter.Angle, LayerMask);
            if (collider)
                return true;
            return false;
        }

    }
}
