using UnityEngine;
using Platformer2DStarterKit.UI;
using Platformer2DStarterKit.AI;

public class BuddhaScene : MonoBehaviour {
    public AIActionListComponent BuddhaAI;
    [System.NonSerialized]
    public BuddhaAIAction BuddhaAIAction;
    public PlayerStatistics PlayerStatistics;
    public AnimationUI AnimationUI;

    private void Awake() {
        PlayerStatistics.CoinAdded += PlayerStatistics_CoinAdded;
    }

    private void PlayerStatistics_CoinAdded(PlayerStatistics source, int currentCoins) {
        if (currentCoins != source.MaxCoins) return;
        AnimationUI.enabled = true;
        BuddhaAIAction.LastPhase(BuddhaAI);
    }

}
