using UnityEngine;
using Platformer2DStarterKit.Utility;

public class PlayerStatistics : MonoBehaviour {
    public CharacterDeath PlayerCharacterDeath;

    private void Awake() {
        PlayerCharacterDeath.Died += PlayerCharacterDeath_Died;
    }

    private void PlayerCharacterDeath_Died(CharacterDeath source, CharacterDeadBody deadBody) {
        AddDeath();
    }

    #region Kills
    public int CurrentKills { get; private set; } = 0;

    public delegate void KillAddedAction(PlayerStatistics source, int currentKills);
    public event KillAddedAction KillAdded;
    public void AddKill() {
        CurrentKills += 1;
        KillAdded?.Invoke(this, CurrentKills);
    }
    #endregion

    #region Deaths
    public int CurrentDeaths { get; private set; } = 0;

    public delegate void DeathAddedAction(PlayerStatistics source, int currentDeaths);
    public event DeathAddedAction DeathAdded;
    public void AddDeath() {
        CurrentDeaths += 1;
        DeathAdded?.Invoke(this, CurrentDeaths);
    }
    #endregion


    #region
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
    #endregion


    public void Save(string saveName) {
        PlayerPrefs.SetInt(saveName + "Kills", CurrentKills);
        PlayerPrefs.SetInt(saveName + "Deaths", CurrentDeaths);
        PlayerPrefs.SetInt(saveName + "Coins", CurrentCoins);
        PlayerPrefs.Save();
    }

}
