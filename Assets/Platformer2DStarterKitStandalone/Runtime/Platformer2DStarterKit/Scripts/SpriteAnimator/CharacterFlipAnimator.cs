using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class CharacterFlipAnimator : MonoBehaviour {
        public Character Character;
        public SpriteRenderer SpriteRenderer;

        private void LateUpdate() {
            switch (Character.Input.Dir) {
                case CharacterInput.Direction.Right:
                    SpriteRenderer.flipX = false;
                    return;
                case CharacterInput.Direction.Left:
                    SpriteRenderer.flipX = true;
                    return;
            }
        }

    }
}
