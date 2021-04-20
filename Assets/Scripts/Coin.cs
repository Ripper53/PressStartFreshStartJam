using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;

public class Coin : MonoBehaviour {
    public PlayerStatistics PlayerStatistics;
    public Check Check;
    public OneShotAudioEffectPooler OneShotAudioEffectPooler;

    private void FixedUpdate() {
        if (!Check.Evaluate()) return;
        gameObject.SetActive(false);
        PlayerStatistics.AddCoin();
        OneShotAudioEffect effect = OneShotAudioEffectPooler.Get();
        effect.Set(transform.position);
        effect.gameObject.SetActive(true);
    }

}
