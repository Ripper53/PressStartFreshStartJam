using System.Collections.Generic;
using UnityEngine;

namespace Platformer2DStarterKit {
    public abstract class SpriteAnimationBase : ScriptableObject {
        /// <summary>
        /// Should the animation loop after it finishes its last frame?
        /// </summary>
        [Tooltip("Should the animation loop after it finishes its last frame?")]
        public bool Loop;
        public abstract IReadOnlyList<Frame> Frames { get; }

        [System.Serializable]
        public abstract class Frame {
            public abstract Sprite Sprite { get; }
            /// <summary>
            /// Time (in seconds) the sprite is shown, before moving onto the next frame.
            /// </summary>
            [Tooltip("Time (in seconds) the sprite is shown, before moving onto the next frame.")]
            public float Interval;
        }

    }
}
