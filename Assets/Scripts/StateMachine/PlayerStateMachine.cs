using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{
    private PlayerInput _playerInput;
    private CharacterController _characterController;
    private Animator _animator;
    private int _isMovingHash;
    private int _isJumpingHash;
    private bool _requireNewJumpPress = false;

    private Vector2 _currentMovementInput;
    private Vector3 _currentMovement;
    private Vector3 _appliedMovement;
    private bool _isMovementPressed;
    [SerializeField] private float _rotationPerFrame = 20f;
    [SerializeField] private float _speed = 5f;

    private float _gravity = -9.8f;

    private bool _isJumpPressed = false;
    private bool _isJumping = false;
    private float _initialJumpVelocity;
    [SerializeField] private float _maxJumpHeight = 4.0f;
    [SerializeField] private float _maxJumpTime = 0.5f;

    private PlayerBaseState _currentState;
    private PlayerStateFactory _states;

    //getters and setters
    public CharacterController CharacterController { get { return _characterController; }} 
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; }} 
    public Animator Animator { get { return _animator;}}
    public Vector2 CurrentMovementInput { get { return _currentMovementInput;}}
    public int IsMovingHash { get { return _isMovingHash;}}
    public int IsJumpingHash { get { return _isJumpingHash;}}
    public bool IsJumpPressed { get { return _isJumpPressed;}}
    public bool IsMovementPressed { get { return _isMovementPressed;}}
    public bool RequireNewJumpPress { get { return _requireNewJumpPress;} set { _requireNewJumpPress = value; }}
    public float Gravity { get { return _gravity;}}
    public float CurrentMovementY { get { return _currentMovement.y;} set { _currentMovement.y = value; }}
    public float AppliedMovementY { get { return _appliedMovement.y;} set { _appliedMovement.y = value; }}
    public float AppliedMovementX { get { return _appliedMovement.x;} set { _appliedMovement.x = value; }}
    public float InitialJumpVelocity { get { return _initialJumpVelocity;}}
    
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();
        
        _isMovingHash = Animator.StringToHash("IsMoving");
        _isJumpingHash = Animator.StringToHash("IsJumping");

        _playerInput.CharacterControls.Move.started += OnMovementInput;
        _playerInput.CharacterControls.Move.canceled += OnMovementInput;
        _playerInput.CharacterControls.Move.performed += OnMovementInput;
        _playerInput.CharacterControls.Jump.started += OnJump;
        _playerInput.CharacterControls.Jump.canceled += OnJump;
        
        SetupJumpVariables();
    }

    private void Start()
    {
        _characterController.Move(_appliedMovement * Time.deltaTime);
    }

    private void Update()
    {
        
        
        HandleRotation();
        _currentState.UpdateStates();
        _characterController.Move(_appliedMovement * Time.deltaTime);
    }

    private void SetupJumpVariables()
    {
        float timeToApex = _maxJumpTime / 2;
        _gravity = (-2 * _maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        _initialJumpVelocity = (2 * _maxJumpHeight) / timeToApex;
    }
    
    private void OnMovementInput(InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        _currentMovement.x = _currentMovementInput.x * _speed;
        _isMovementPressed = _currentMovement.x != 0;
    }
    
    private void OnJump(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValueAsButton();
        _requireNewJumpPress = false;
    }
    
    private void HandleRotation()
    {
        Vector3 positionToLookAt = new Vector3(_currentMovement.x, 0,0);
        Quaternion currentRotation = transform.rotation;
        if (_isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationPerFrame*Time.deltaTime);
        }
    }
    
    private void OnEnable()
    {
        _playerInput.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        _playerInput.CharacterControls.Disable();
    }

    
}
