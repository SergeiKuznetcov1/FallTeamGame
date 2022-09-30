using UnityEngine;

public class Enemy : MonoBehaviour
{
	private string currentState = "IdleState";
    private Animator _animator;
    [SerializeField] private Transform target;
    [SerializeField] private float _chaseRange;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _moveSpeed;

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        float distance = Vector3.Distance(transform.position, target.position);

        if (currentState == "IdleState") {
            if (distance < _chaseRange) {
                currentState = "ChaseState";
            }
        }
        else if (currentState == "ChaseState") {
            _animator.SetTrigger("Chase");
            _animator.SetBool("IsAttacking", false);

            if (distance < _attackRange) {
                currentState = "AttackState";
            }

            if (target.position.x > transform.position.x) {
                // move left
                transform.Translate(-transform.right * _moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            } 
            else {
                // move right
                transform.Translate(transform.right * _moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }

        else if (currentState == "AttackState") {
            _animator.SetBool("IsAttacking", true);
            if (distance > _attackRange) {
                currentState = "ChaseState";
            }   
        }
    }
}
