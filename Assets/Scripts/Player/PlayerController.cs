using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float knockBackLength, knockBackForce;
    public float knockBackCounter;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity;
    [SerializeField] private float _groundCheckRadius;
    private PlayerControls _playerControls;
    private Animator _animator;
	private CharacterController _controller;
    private Vector3 _direction;
    private float _hInput;
    private bool _fireballAttack;
    private bool _isGrounded = true; 
    private bool _doubleJumpAble = true;
    public float HorInput { get => _hInput; }
    public bool FireballAttack { get => _fireballAttack; set => _fireballAttack = value; }
    public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
    public bool DoubleJumpAble { get => _doubleJumpAble; }

    private void Awake() {
        instance = this;
        _playerControls = new PlayerControls();
        _playerControls.Enable();

        _playerControls.Land.Move.performed += ctx => {
            _hInput = ctx.ReadValue<float>();
        };

        _playerControls.Land.Jump.performed += ctx => {
            Jump();
        };

        _playerControls.Land.Fireball.performed += ctx => {
            Fireball();
        };
    }

    private void OnEnable() {
        _isGrounded = true;
    }
    private void Start() {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();


    }

    private void Update() {
  
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundLayer);
        IncreaseGravity(); 
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Fireball")) {
            return;
        }
        if (knockBackCounter <= 0) {
            MoveHorizontal();
            ChangeRotation();
            _controller.Move(_direction * Time.deltaTime);
        } 
        else {
            knockBackCounter -=  Time.deltaTime;
            _controller.Move(_direction * Time.deltaTime);
        }
    }

    private void MoveHorizontal() {
        // old move input
        //_hInput = Input.GetAxis("Horizontal");
        _direction.x = -_hInput * _moveSpeed;
    }

    private void IncreaseGravity() {
        if (_direction.y > _gravity) {
            _direction.y += _gravity * Time.deltaTime;
        }
    }

    private void Jump() {
        if (_isGrounded) {
            _doubleJumpAble = true;
            _direction.y = _jumpForce;
            /*
            if (Input.GetButtonDown("Jump")) {
                _direction.y = _jumpForce;
            }
            
            if (Input.GetKeyDown(KeyCode.F)) {
                _fireballAttack = true;
            }
            */
        }
        // turn of DoubleJump
        /*
        else {
            if (_doubleJumpAble) {
                _direction.y = _jumpForce;
                _doubleJumpAble = false;
            }
        } 
        */
    }

    private void Fireball() {
        if (_isGrounded) {
            _fireballAttack = true;
        }
    }

    private void ChangeRotation() {
        if (_hInput != 0) {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(-_hInput, 0, 0));
            transform.rotation = newRotation;
        }
    }

    public void KnockBack() {
        knockBackCounter = knockBackLength;
        if (transform.rotation.y < 0) {
            _direction = new Vector3(knockBackForce, knockBackForce, 0);
        }
        else if (transform.rotation.y > 0) {
            _direction = new Vector3(-knockBackForce, knockBackForce, 0);
        }
    }
}
