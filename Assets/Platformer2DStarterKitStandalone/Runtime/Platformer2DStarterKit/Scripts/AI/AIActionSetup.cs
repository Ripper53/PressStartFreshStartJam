using UnityEngine;

namespace Platformer2DStarterKit.AI {
    public abstract class AIActionSetup : MonoBehaviour {

        private void Start() {
            Setup(GetComponent<ICharacter>());
        }

        protected abstract void Setup(ICharacter character);

    }
}
