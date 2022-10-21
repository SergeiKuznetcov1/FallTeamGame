using UnityEngine;
using System.Collections.Generic;
public class PatrolSpot : MonoBehaviour
{
	[SerializeField] private Transform _enemy;
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private float _moveSpeed;
    private LinkedListNode<Transform> _moveTarget;
    private Transform _destinationPoint;
    private int _destinationIndex = 0;
    private LinkedList<Transform> _checkpoints; 
    private void Start() {
        _destinationPoint = _patrolPoints[_destinationIndex];
        _checkpoints = new LinkedList<Transform>(_patrolPoints);
        _moveTarget = _checkpoints.First;
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
                print(_enemy.eulerAngles);
            }
            print(_enemy.eulerAngles);
            _destinationPoint = _patrolPoints[_destinationIndex];
            _enemy.position = Vector3.MoveTowards(_enemy.position, _destinationPoint.position, _moveSpeed * Time.deltaTime);
        }
    }

    private void Update2() {
        if (_enemy == null) 
            return;
        
        // if we reached point we set move target to next point
        // if there is no next point we set move target to the first checkpoint
        // we need to make enemy look at next point

        if (Mathf.Approximately(Vector3.Distance(_enemy.position, _destinationPoint.position), 0)) {
            
        }
    }
}
