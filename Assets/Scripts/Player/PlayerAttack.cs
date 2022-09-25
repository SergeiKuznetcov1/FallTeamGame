using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _P_fireball;
    [SerializeField] private Transform _P_fireballPoint;
    [SerializeField] private float _fireballSpeed;
	public void FireballAttack() {
        GameObject fireball = Instantiate(_P_fireball, _P_fireballPoint.position, transform.rotation);
        //fireball.GetComponent<Rigidbody>().AddForce(_P_fireballPoint.forward * _fireballSpeed);
    }
}
