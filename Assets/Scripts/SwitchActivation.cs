using UnityEngine;

public class SwitchActivation : MonoBehaviour
{
	[SerializeField] private GameObject _activationObject;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _activationObject.SetActive(true);
        }
    }
}
