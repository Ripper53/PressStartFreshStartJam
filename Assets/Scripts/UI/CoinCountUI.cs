using UnityEngine;
using TMPro;

public class CoinCountUI : MonoBehaviour {
    public PlayerStatistics PlayerStatistics;
    public TextMeshProUGUI Text;

    private void Awake() {
        PlayerStatistics.CoinAdded += PlayerStatistics_CoinAdded;
        PlayerStatistics.MaxCoinAdded += PlayerStatistics_MaxCoinAdded;
    }

    private void PlayerStatistics_CoinAdded(PlayerStatistics source, int currentCoins) {
        Text.text = $"{currentCoins}/{source.MaxCoins}";
    }

    private void PlayerStatistics_MaxCoinAdded(PlayerStatistics source, int maxCoins) {
        Text.text = $"{source.CurrentCoins}/{maxCoins}";
    }

}
