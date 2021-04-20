using UnityEngine;

public class PlayerStatistics : MonoBehaviour {
    public int CurrentCoins { get; private set; } = 0;

    public delegate void CoinAddedAction(PlayerStatistics source, int currentCoins);
    public event CoinAddedAction CoinAdded;
    public void AddCoin() {
        CurrentCoins += 1;
        CoinAdded?.Invoke(this, CurrentCoins);
    }

}
