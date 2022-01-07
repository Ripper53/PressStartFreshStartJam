using UnityEngine;

namespace Platformer2DStarterKit {
    public class CircleCheck : LayerCheck {
        public CircleParameter CircleParameter;
        public override ShapeParameter ShapeParameter => CircleParameter;

        public override bool Evaluate() {
            return Physics2D.OverlapCircle(CircleParameter.Position, CircleParameter.Radius, LayerMask);
        }

    }
}
