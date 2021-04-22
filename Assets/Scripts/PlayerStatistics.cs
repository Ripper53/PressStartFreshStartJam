using UnityEngine;

public class PlayerStatistics : MonoBehaviour {
    public int CurrentCoins { get; private set; } = 0;
    public int MaxCoins { get; private set; } = 0;


    public delegate void MaxCoinAddedAction(PlayerStatistics source, int maxCoins);
    public event MaxCoinAddedAction MaxCoinAdded;
    public void AddMaxCoin() {
        MaxCoins += 1;
        MaxCoinAdded?.Invoke(this, MaxCoins);
    }

    public delegate void CoinAddedAction(PlayerStatistics source, int currentCoins);
    public event CoinAddedAction CoinAdded;
    public void AddCoin() {
        CurrentCoins += 1;
        CoinAdded?.Invoke(this, CurrentCoins);
    }

}
