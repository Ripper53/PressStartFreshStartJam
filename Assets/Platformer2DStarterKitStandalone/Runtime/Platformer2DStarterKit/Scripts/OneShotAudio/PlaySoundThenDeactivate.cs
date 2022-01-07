using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class PlaySoundThenDeactivate : PlaySound {
        public GameObject GameObject;

        private void Update() {
            if (!AudioSource.isPlaying)
                GameObject.SetActive(false);
        }

    }
}
