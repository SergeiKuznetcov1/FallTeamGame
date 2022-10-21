using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // [SerializeField] private GameObject activateObject;
	private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // CheckpointsController.instance.DeactivateCheckpoints();
            CheckpointsController.instance.SetSpawnPoint(transform.position);

            // if (activateObject != null) {
            //     activateObject.SetActive(true);
            // }
        }
    }

    public void ResetCheckpoint() {

    }
}
