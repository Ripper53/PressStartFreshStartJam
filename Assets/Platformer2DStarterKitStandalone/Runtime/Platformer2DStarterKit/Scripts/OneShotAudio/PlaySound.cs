using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class PlaySound : MonoBehaviour {
        public AudioSource AudioSource;

        private void OnEnable() {
            AudioSource.Play();
        }

    }
}
