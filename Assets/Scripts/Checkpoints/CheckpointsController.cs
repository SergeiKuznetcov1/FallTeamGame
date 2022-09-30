using UnityEngine;

public class CheckpointsController : MonoBehaviour
{
	public static CheckpointsController instance;
    public Vector3 spawnPoint;
    private Checkpoint[] _checkpoints;
    private void Awake() {
        instance = this;
    }

    private void Start() {
        _checkpoints = FindObjectsOfType<Checkpoint>();
    }
    // Nothing to deactivate for now
    /*
    public void DeactivateCheckpoints() {
        for (int i = 0; i < _checkpoints.Length; i++) {
            _checkpoints[i].ResetCheckpoint();
        }
    }
    */
    public void SetSpawnPoint(Vector3 newSpawnPoint) {
        spawnPoint = newSpawnPoint;
    }
}
