using UnityEngine;

public class Damageable : MonoBehaviour
{
    /*
	private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Fireball")) {
        }
    }
    */
    public void DealDamage() {
        Destroy(gameObject, 0.15f);
    }
}
