using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class CharacterDeath : MonoBehaviour {
        public GameObject CharacterObj;
        public Transform Transform;
        public SpriteRenderer SpriteRenderer;
        public DeadBody DeadBody;

        [SerializeField]
        private CharacterDeadBodyPooler characterDeadBodyPooler;
        public void Initialize(CharacterDeadBodyPooler characterDeadBodyPooler) {
            this.characterDeadBodyPooler = characterDeadBodyPooler;
        }

        public delegate void DiedAction(CharacterDeath source, CharacterDeadBody deadBody);
        public event DiedAction Died;

        public CharacterDeadBody Die() {
            CharacterObj.SetActive(false);
            CharacterDeadBody deadBody = characterDeadBodyPooler.Get();
            deadBody.Set(Transform.position, SpriteRenderer.flipX, DeadBody);
            deadBody.gameObject.SetActive(true);
            Died?.Invoke(this, deadBody);
            return deadBody;
        }

        public static void Kill(GetColliders getColliders) {
            foreach (Collider2D col in getColliders.Get())
                Kill(col);
        }

        public static bool Kill(Component component) {
            if (component.TryGetComponent(out CharacterDeath characterDeath)) {
                characterDeath.Die();
                return true;
            }
            return false;
        }

        public static bool Kill(GameObject gameObject, out CharacterDeadBody characterDeadBody) {
            if (gameObject.TryGetComponent(out CharacterDeath characterDeath)) {
                characterDeadBody = characterDeath.Die();
                return true;
            }
            characterDeadBody = null;
            return false;
        }

    }
}
