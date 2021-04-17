using UnityEngine;
using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;

public class EnterLoadScene : MonoBehaviour {
    public LoadScene LoadScene;
    public string SceneName;

    public Check Check;

    private void FixedUpdate() {
        if (Check.Evaluate()) {
            LoadScene.Load(SceneName);
            enabled = false;
        }
    }

}
