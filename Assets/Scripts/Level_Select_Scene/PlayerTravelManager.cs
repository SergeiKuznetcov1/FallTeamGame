using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTravelManager : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;
	[SerializeField] private Transform[] _levelButtons;
    [SerializeField] private Transform _player;
    [SerializeField] private float _moveSpeed;
    private Vector3 _playerLevelGap;
    private bool _isMoving;
    private int _levelIndex;

    private void Start() {
        _playerLevelGap = _player.transform.position - _levelButtons[0].transform.position;
    }

    private void Update() {
        MoveToLevel(_levelIndex);
    }

    private void MoveToLevel(int levelIndex) {
        if (!_isMoving) 
            return;

        _player.position = 
            Vector3.MoveTowards(_player.transform.position, _levelButtons[levelIndex].position + _playerLevelGap, _moveSpeed);

        if (Mathf.Approximately(_player.position.x, _levelButtons[levelIndex].position.x + _playerLevelGap.x)) {
            _isMoving = false;
            _levelLoader.LoadScene(_levelIndex + 1);
        }
            
    } 

    public void MovePlayerToLevel(int buttonIndex) {
        _isMoving = true;
        _levelIndex = buttonIndex;
    }
}
