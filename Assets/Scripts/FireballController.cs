using UnityEngine;

public class FireballController : MonoBehaviour
{
    [SerializeField] private GameObject _damageEffect;
    [SerializeField] private float _moveSpeed;
	private void FixedUpdate() {
        transform.Translate(0, 0, _moveSpeed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Damageable>()) {
            Instantiate(_damageEffect, transform.position, transform.rotation);
            other.gameObject.GetComponent<Damageable>().DealDamage();
            Destroy(gameObject);
        }
    }
}
