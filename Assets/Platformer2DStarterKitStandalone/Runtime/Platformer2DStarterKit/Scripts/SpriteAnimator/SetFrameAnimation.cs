using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class SetFrameAnimation : MonoBehaviour {
        public FrameAnimator FrameAnimator;
        public SpriteAnimationBase SpriteAnimation;

        private void OnEnable() {
            FrameAnimator.SetSprite(SpriteAnimation.Frames[0].Sprite);
            FrameAnimator.SetAnimation(SpriteAnimation);
        }

    }
}
