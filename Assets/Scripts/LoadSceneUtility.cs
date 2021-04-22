using UnityEngine;
using Platformer2DStarterKit.Utility;

public class LoadSceneUtility : MonoBehaviour {
    public LoadScene LoadScene;
    public string SceneName;

    public void Load() {
        LoadScene.Load(SceneName);
    }

}
