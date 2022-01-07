using UnityEngine;

namespace Platformer2DStarterKit {
    public class SpriteAnimator : FrameAnimator {
        public SpriteRenderer SpriteRenderer;

        public override void SetSprite(Sprite sprite) {
            SpriteRenderer.sprite = sprite;
        }

    }
}
