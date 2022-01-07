using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit {
    /// <summary>
    /// Gets colliders contained within the tile size.
    /// </summary>
    public class SpriteTileGetColliders : LayerGetColliders {
        public SpriteTileParameter SpriteTileParameter;
        public override ShapeParameter ShapeParameter => SpriteTileParameter;

        public override IEnumerable<Collider2D> Get() {
            return Physics2D.OverlapBoxAll(SpriteTileParameter.Position, SpriteTileParameter.Scale, SpriteTileParameter.Angle, LayerMask);
        }

        public override bool Get(out Collider2D collider) {
            collider = Physics2D.OverlapBox(SpriteTileParameter.Position, SpriteTileParameter.Scale, SpriteTileParameter.Angle, LayerMask);
            if (collider)
                return true;
            return false;
        }

    }
}
