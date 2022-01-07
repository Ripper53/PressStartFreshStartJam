using UnityEngine;

namespace Platformer2DStarterKit {
    public class BoxCheck : LayerCheck {
        public BoxParameter BoxParameter;
        public override ShapeParameter ShapeParameter => BoxParameter;

        public override bool Evaluate() {
            return Physics2D.OverlapBox(BoxParameter.Position, BoxParameter.Scale, BoxParameter.Angle, LayerMask);
        }

    }
}
