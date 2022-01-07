using UnityEngine;

namespace Platformer2DStarterKit.Utility {
    public class DeactivateGameObjectAfterTime : MonoBehaviour {
        public GameObject GameObject;
        public float Time;

        private readonly Timer timer = new Timer();

        private void OnEnable() {
            timer.SetTime(Time);
        }

        private void Update() {
            if (timer.Execute(UnityEngine.Time.deltaTime)) return;
            GameObject.SetActive(false);
        }

    }
}
