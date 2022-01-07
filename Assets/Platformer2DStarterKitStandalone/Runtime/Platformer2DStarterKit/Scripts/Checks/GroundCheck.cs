using UnityEngine;

namespace Platformer2DStarterKit {
    public class GroundCheck : Check {
        /// <summary>
        /// The GameObject itself, so it is ignored when checking for ground.
        /// </summary>
        [Space]
        [Tooltip("The GameObject itself, so it is ignored when checking for ground.")]
        public GameObject SelfGameObject;
        public Character Character;
        public Check Check;
        public int CoyoteTime;
        public override ShapeParameter ShapeParameter => Check.ShapeParameter;

        private int coyoteTimer = 0;
        private bool evaluation = false;
        public override bool Evaluate() => evaluation && Character.CurrentState != Character.State.Jumping && Character.CurrentState != Character.State.Stunned;

        private void FixedUpdate() {
            int savedLayer = SelfGameObject.layer;
            SelfGameObject.layer = 2; // Temp. ignore raycasts so check does not detect itself!
            evaluation = Check.Evaluate();
            SelfGameObject.layer = savedLayer;

            if (evaluation) {
                coyoteTimer = CoyoteTime;
            } else if (coyoteTimer > 0) {
                switch (Character.CurrentState) {
                    case Character.State.Jumping:
                    case Character.State.Stunned:
                        evaluation = false;
                        coyoteTimer = 0;
                        return;
                    default:
                        evaluation = true;
                        coyoteTimer -= 1;
                        return;
                }
            }
        }

    }
}
