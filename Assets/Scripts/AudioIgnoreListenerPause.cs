using UnityEngine;

public class AudioIgnoreListenerPause : MonoBehaviour {
    public AudioSource AudioSource;

    private void Awake() {
        AudioSource.ignoreListenerPause = true;
    }

}
