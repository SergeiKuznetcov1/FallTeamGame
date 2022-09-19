using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity;
	private CharacterController _controller;
    private CapsuleCollider _collider;
    private Vector3 _direction;
    private float _hInput;
    private bool _isGrounded = true; 
    private bool _doubleJumpAble = true;
    public float HorInput { get => _hInput; }
    public bool IsGrounded { get => _isGrounded; }
    public bool DoubleJumpAble { get => _doubleJumpAble; }

    private void Start() {
        _controller = GetComponent<CharacterController>();
        _collider = GetComponent<CapsuleCollider>();
    }

    private void Update() {
        MoveHorizontal();
        _isGrounded = Physics.CheckSphere(_groundCheck.position, 1f, _groundLayer);
        IncreaseGravity();
        Jump();     
        ChangeRotation();
        _controller.Move(_direction * Time.deltaTime);
    }

    private void MoveHorizontal() {
        _hInput = Input.GetAxis("Horizontal");
        _direction.x = _hInput * _moveSpeed;
    }

    private void IncreaseGravity() {
        if (_direction.y > _gravity) {
            _direction.y += _gravity * Time.deltaTime;
        }
    }

    private void Jump() {
        if (_isGrounded) {
            _doubleJumpAble = true;
            if (Input.GetButtonDown("Jump")) {
                _direction.y = _jumpForce;
            }
        }
        else {
            if (_doubleJumpAble & Input.GetButtonDown("Jump")) {
                _direction.y = _jumpForce;
                _doubleJumpAble = false;
            }
        } 
    }

    private void ChangeRotation() {
        if (_hInput != 0) {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(_hInput, 0, 0));
            transform.rotation = newRotation;
        }
    }
}
