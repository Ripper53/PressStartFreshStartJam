using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Platformer2DStarterKit {
    [CreateAssetMenu(fileName = "New Sprite Atlas Animation", menuName = "Platformer 2D Starter-Kit/Sprite Atlas Animation")]
    public class SpriteAtlasAnimation : SpriteAnimationBase {
        [SerializeField]
        private AtlasFrame[] frames;
        public override IReadOnlyList<Frame> Frames => frames;

        [System.Serializable]
        public class AtlasFrame : Frame {
            public SpriteAtlas SpriteAtlas;
            public string SpriteName;
            private Sprite sprite;
            public override Sprite Sprite {
                get {
                    if (!sprite)
                        sprite = SpriteAtlas.GetSprite(SpriteName);
                    return sprite;
                }
            }
        }

    }
}
