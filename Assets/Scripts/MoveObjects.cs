using UnityEngine;

public class MoveObjects : MonoBehaviour
{
	[SerializeField] private Transform _moveTarget;
	[SerializeField] private Transform _finishPosition;
	[SerializeField] private float _moveSpeed;

    private void Update() {
        _moveTarget.position = Vector3.MoveTowards(_moveTarget.position, _finishPosition.position, _moveSpeed * Time.deltaTime);
    }
}
