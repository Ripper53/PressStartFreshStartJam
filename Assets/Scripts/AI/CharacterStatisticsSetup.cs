using UnityEngine;
using Platformer2DStarterKit.Utility;

public class CharacterStatisticsSetup : MonoBehaviour {
    public CharacterDeath CharacterDeath;
    public PlayerStatistics PlayerStatistics;

    private void Awake() {
        CharacterDeath.Died += CharacterDeath_Died;
    }

    private void CharacterDeath_Died(CharacterDeath source, CharacterDeadBody deadBody) {
        PlayerStatistics.AddKill();
    }

}
