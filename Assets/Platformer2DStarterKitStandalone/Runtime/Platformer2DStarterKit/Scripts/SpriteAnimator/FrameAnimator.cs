using UnityEngine;
using Platformer2DStarterKit.Utility;

namespace Platformer2DStarterKit {
    public abstract class FrameAnimator : MonoBehaviour {
        public SpriteAnimationBase CurrentSpriteAnimation { get; private set; }
        public int CurrentFrameIndex { get; private set; }

        private SpriteAnimationBase.Frame CurrentFrame => CurrentSpriteAnimation.Frames[CurrentFrameIndex];

        /// <summary>
        /// True if there is no animation, or if the animation is not a loop and is on its last frame with its interval finished, otherwise false.
        /// </summary>
        /// Seems like it doesn't check for loop? If CurrentFrameIndex is the same as the length of the frames, then it already made sure it was not a loop in Update.
        /// Short answer: CurrentFrameIndex will never equal the number of frames if it is loopable!
        public bool IsFinished => !CurrentSpriteAnimation || (CurrentFrameIndex == CurrentSpriteAnimation.Frames.Count && IntervalTimer.IsOver);

        public Timer IntervalTimer { get; } = new Timer();

        public void SetAnimation(SpriteAnimationBase spriteAnimation) {
            CurrentSpriteAnimation = spriteAnimation;
            CurrentFrameIndex = 0;
            IntervalTimer.SetTime(0f);
        }

        private void Update() {
            // If there is no animation, or the animation has reached its end and is not loopable, exit the method.
            if (IsFinished) return;

            if (!IntervalTimer.Execute(Time.deltaTime)) {
                SetSprite(CurrentFrame.Sprite);
                IntervalTimer.SetTime(CurrentFrame.Interval);
                CurrentFrameIndex += 1;
                // Reset CurrentFrameIndex to 0 if the animation is loopable and we have reached the end.
                if (CurrentSpriteAnimation.Frames.Count == CurrentFrameIndex && CurrentSpriteAnimation.Loop)
                    CurrentFrameIndex = 0;
            }
        }

        public abstract void SetSprite(Sprite sprite);

    }
}
