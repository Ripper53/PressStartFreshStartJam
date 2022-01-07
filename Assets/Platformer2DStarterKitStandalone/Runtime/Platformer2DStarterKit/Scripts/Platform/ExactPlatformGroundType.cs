using UnityEngine;

namespace Platformer2DStarterKit {
    public class ExactPlatformGroundType : PlatformGroundType {

        private Vector2 lastPosition;

        public override void Initialize(PlatformGround platformGround) {
            lastPosition = platformGround.MovementExecution.Rigidbody.position;
        }

        public override Vector2 GetMovement(PlatformGround platformGround) {
            Vector2 diff = platformGround.MovementExecution.Rigidbody.position - lastPosition;
            lastPosition = platformGround.MovementExecution.Rigidbody.position;
            return diff;
        }

    }
}
