using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            //CheckpointsController.instance.DeactivateCheckpoints();
            CheckpointsController.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckpoint() {

    }
}
