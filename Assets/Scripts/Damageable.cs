using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private GameObject _itemToDrop;
    [SerializeField] private float destroyDelay;
    /*
	private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Fireball")) {
        }
    }
    */
    public void DealDamage() {
        Destroy(gameObject, destroyDelay);
        if (_itemToDrop != null) {
            Instantiate(_itemToDrop, transform.position, transform.rotation);
        }
    }
}
