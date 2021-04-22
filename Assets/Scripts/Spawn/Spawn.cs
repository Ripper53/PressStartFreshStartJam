using UnityEngine;
using Platformer2DStarterKit.AI;
using Platformer2DStarterKit.Utility;

public class Spawn : MonoBehaviour {
    public AIActionListComponentObjectPooler AIPooler;
    public Transform Origin;
    public float MinTime, MaxTime;

    private readonly Timer timer = new Timer();

    private void OnEnable() {
        SetTime();
    }

    public delegate void SpawnedAction(Spawn source, AIActionListComponent ai);
    public event SpawnedAction Spawned;
    private void FixedUpdate() {
        if (timer.Execute(Time.fixedDeltaTime)) return;
        AIActionListComponent ai = AIPooler.Get();
        ai.Position = Origin.position;
        ai.gameObject.SetActive(true);
        gameObject.SetActive(false);
        Spawned?.Invoke(this, ai);
    }

    private void SetTime() {
        timer.SetTime(Random.Range(MinTime, MaxTime));
    }

}
