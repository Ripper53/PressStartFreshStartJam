using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit {
    [CreateAssetMenu(fileName = "New Sprite Animation", menuName = "Platformer 2D Starter-Kit/Sprite Animation")]
    public class SpriteAnimation : SpriteAnimationBase {
        [SerializeField]
        private SpriteFrame[] frames;
        public override IReadOnlyList<Frame> Frames => frames;

        [System.Serializable]
        public class SpriteFrame : Frame {
            [SerializeField]
            private Sprite sprite;
            public override Sprite Sprite => sprite;
        }

    }
}
