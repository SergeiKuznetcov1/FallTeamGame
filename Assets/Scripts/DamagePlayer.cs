using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PlayerHealthController.instance.DealDamage();
        }
    }
}
