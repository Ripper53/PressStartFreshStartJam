using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    [CreateAssetMenu(fileName = "New Dead Body", menuName = "Platformer 2D Starter-Kit/Dead Body")]
    public class DeadBody : ScriptableObject {
        public SpriteAnimationBase Animation;
        public Vector2 ColliderOffset, ColliderSize;
    }
}
