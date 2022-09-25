using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
	private void FixedUpdate() {
        transform.Translate(0, 0, moveSpeed);
    }
}
