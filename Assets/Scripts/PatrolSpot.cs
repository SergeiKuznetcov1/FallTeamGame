using UnityEngine;

public class PatrolSpot : MonoBehaviour
{
	[SerializeField] private Transform _enemy;
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private float _moveSpeed;
    private Transform _destinationPoint;
    private int _destinationIndex = 0;
    
    private void Start() {
        _destinationPoint = _patrolPoints[_destinationIndex];
    }

    private void Update() {
        if (_enemy != null) {
            if (Mathf.Approximately(_destinationPoint.position.x, _enemy.position.x)) {
                if (_destinationIndex == _patrolPoints.Length - 1) {
                    _destinationIndex = 0;
                } 
                else {
                    _destinationIndex++;
                }
                // _enemy.eulerAngles = new Vector3(_enemy.eulerAngles.x, _enemy.eulerAngles.y + 180, _enemy.eulerAngles.z);
                _enemy.localScale = new Vector3(_enemy.localScale.x * -1, _enemy.localScale.y, _enemy.localScale.z); 
            }
            _destinationPoint = _patrolPoints[_destinationIndex];
            _enemy.position = Vector3.MoveTowards(_enemy.position, _destinationPoint.position, _moveSpeed * Time.deltaTime);
        }
    }
}
