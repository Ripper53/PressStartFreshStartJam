using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class OneShotAudio : MonoBehaviour {
        public AudioSource AudioSource;
        public Transform Transform;

        public void Set(AudioClip clip, Vector2 position) {
            AudioSource.clip = clip;
            Transform.position = position;
        }

    }
}
