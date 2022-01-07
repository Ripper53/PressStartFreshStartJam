using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class OneShotAudioEffect : MonoBehaviour {
        public AudioClip AudioClip;
        public Transform Transform;

        private OneShotAudioPooler oneShotAudioPooler;

        public void Initialize(OneShotAudioPooler oneShotAudioPooler) {
            this.oneShotAudioPooler = oneShotAudioPooler;
        }

        public void Set(Vector2 position) {
            Transform.position = position;
        }

        private void OnEnable() {
            OneShotAudio audio = oneShotAudioPooler.Get();
            audio.Set(AudioClip, Transform.position);
            audio.gameObject.SetActive(true);
        }

    }
}
