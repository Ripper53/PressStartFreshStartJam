using UnityEngine;
using Platformer2DStarterKit.Utility;

public class CharacterDeathAudio : MonoBehaviour {
    public CharacterDeath CharacterDeath;
    public Transform Transform;
    public OneShotAudioPooler OneShotAudioPooler;
    public AudioClip AudioClip;

    private void Awake() {
        CharacterDeath.Died += CharacterDeath_Died;
    }

    private void CharacterDeath_Died(CharacterDeath source, CharacterDeadBody deadBody) {
        OneShotAudio audio = OneShotAudioPooler.Get();
        audio.Set(AudioClip, Transform.position);
        audio.gameObject.SetActive(true);
    }

}
