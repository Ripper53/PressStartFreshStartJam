using UnityEngine;
using Platformer2DStarterKit.Utility;

public class CharacterDeathSound : MonoBehaviour {
    public CharacterDeath CharacterDeath;
    public OneShotAudioEffectPooler OneShotAudioEffectPooler;

    private void Awake() {
        CharacterDeath.Died += CharacterDeath_Died;
    }

    private void CharacterDeath_Died(CharacterDeath source, CharacterDeadBody deadBody) {
        OneShotAudioEffect effect = OneShotAudioEffectPooler.Get();
        effect.Set(source.Transform.position);
        effect.gameObject.SetActive(true);
    }

}
