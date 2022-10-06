using UnityEngine;

public class EnergyPickUp : MonoBehaviour
{
    [SerializeField] private float _energyAmount;
	private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            LevelEnergyManager.instance.AddEnergy(_energyAmount / 100);
            Destroy(gameObject);
        }
    }
}
