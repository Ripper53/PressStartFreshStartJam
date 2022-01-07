using UnityEngine;
using UnityEngine.UI;

namespace Platformer2DStarterKit {
    public class ImageAnimator : FrameAnimator {
        public Image Image;

        public override void SetSprite(Sprite sprite) {
            Image.sprite = sprite;
        }

    }
}
