using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;

public class EnterLoadScene : MonoBehaviour {
    public LoadScene LoadScene;
    public string SceneName;

    public Check Check;
    public PlayerStatistics PlayerStatistics;

    private void FixedUpdate() {
        if (Check.Evaluate()) {
            PlayerStatistics.Save(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            LoadScene.Load(SceneName);
            enabled = false;
        }
    }

}
