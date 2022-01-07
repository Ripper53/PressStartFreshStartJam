using UnityEngine;
using UnityEngine.UI;

namespace Platformer2DStarterKit.UI {
    public class FadeHoverUI : MonoBehaviour {
        public Image FadeImage;
        public float FadeSpeed = 5f;
        /// <summary>
        /// The target alpha when NOT hovering.
        /// </summary>
        [Tooltip("The target alpha when NOT hovering.")]
        public float FadeExit = 0f;
        /// <summary>
        /// The target alpha when hovering.
        /// </summary>
        [Tooltip("The target alpha when hovering.")]
        public float FadeEnter = 1f;

        protected float targetAlpha;

        private void OnEnable() {
            targetAlpha = FadeExit;
        }

        public void FadeIn() {
            targetAlpha = FadeEnter;
        }
        public void FadeOut() {
            targetAlpha = FadeExit;
        }

        private void Update() {
            Color color = FadeImage.color;
            color.a = Mathf.Lerp(color.a, targetAlpha, FadeSpeed * Time.deltaTime);
            FadeImage.color = color;
        }

    }
}
