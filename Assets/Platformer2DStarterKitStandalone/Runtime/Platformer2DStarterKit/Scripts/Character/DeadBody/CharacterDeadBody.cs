using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class CharacterDeadBody : MonoBehaviour {
        public Transform Transform;
        public SpriteRenderer SpriteRenderer;
        public SetFrameAnimation SetFrameAnimation;
        public BoxCollider2D BoxCollider;

        public void Set(Vector2 position, bool flipX, DeadBody deadBody) {
            Transform.position = position;
            SpriteRenderer.flipX = flipX;
            SetFrameAnimation.SpriteAnimation = deadBody.Animation;
            BoxCollider.offset = deadBody.ColliderOffset;
            BoxCollider.size = deadBody.ColliderSize;
        }

    }
}
