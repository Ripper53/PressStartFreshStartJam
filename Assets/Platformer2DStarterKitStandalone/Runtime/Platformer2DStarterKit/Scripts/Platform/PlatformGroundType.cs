using UnityEngine;

namespace Platformer2DStarterKit {
    public abstract class PlatformGroundType : MonoBehaviour {
        public abstract void Initialize(PlatformGround platformGround);
        public abstract Vector2 GetMovement(PlatformGround platformGround);
    }
}
