using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Platformer2DStarterKit;
using Platformer2DStarterKit.AI;

public class BuddhaScene : MonoBehaviour {
    public AIActionListComponent BuddhaAI;
    [System.NonSerialized]
    public BuddhaAIAction BuddhaAIAction;
    public PlayerStatistics PlayerStatistics;

    private void Awake() {
        PlayerStatistics.CoinAdded += PlayerStatistics_CoinAdded;
    }

    private void PlayerStatistics_CoinAdded(PlayerStatistics source, int currentCoins) {
        if (currentCoins != source.MaxCoins) return;
        BuddhaAIAction.LastPhase(BuddhaAI);
    }

}
