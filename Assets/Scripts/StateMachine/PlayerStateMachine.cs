using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInputReader _playerInputReader;
    private CharacterController _characterController;
    private Animator _animator;
    private RotationHandler _rotationHandler;
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
    //private float _initialJumpVelocity;
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
    public float Gravity { get { return _gravity;} set{ _gravity = value;}}
    public float Speed { get { return _speed;}}
    public float RotationPerFrame { get { return _rotationPerFrame;}}
    public float MaxJumpHeight { get { return _maxJumpHeight;}}
    public float MaxJumpTime { get { return _maxJumpTime;}}
    public float CurrentMovementY { get { return _currentMovement.y;} set { _currentMovement.y = value; }}
    //public float CurrentMovementX { get { return _currentMovement.x;} set { _currentMovement.x = value; }}
    public float AppliedMovementY { get { return _appliedMovement.y;} set { _appliedMovement.y = value; }}
    public float AppliedMovementX { get { return _appliedMovement.x;} set { _appliedMovement.x = value; }}
    //public float InitialJumpVelocity { get { return _initialJumpVelocity;}}
    
    
    private void Awake()
    {
        //_playerInput = new PlayerInput();
        _playerInputReader = gameObject.AddComponent<PlayerInputReader>();
        _rotationHandler = new RotationHandler();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();
        
        _isMovingHash = Animator.StringToHash("IsMoving");
        _isJumpingHash = Animator.StringToHash("IsJumping");


        _playerInputReader.OnMoving += (movementVector, movementButtonPressed) =>
        {
            _currentMovementInput = movementVector;
            _isMovementPressed = movementButtonPressed;
        };
        _playerInputReader.OnJumpPressed += (jumpButtonPressed) =>
        {
            _isJumpPressed = jumpButtonPressed;
            _requireNewJumpPress = false;
        };
        
        //_currentMovementInput = _playerInputReader.movementInput;
        //_isMovementPressed = _playerInputReader.isMovementPressed;
        //_isJumpPressed = _playerInputReader.isJumpPressed;
        
        // _playerInput.CharacterControls.Move.started += OnMovementInput;
        // _playerInput.CharacterControls.Move.canceled += OnMovementInput;
        // _playerInput.CharacterControls.Move.performed += OnMovementInput;
        // _playerInput.CharacterControls.Jump.started += OnJump;
        // _playerInput.CharacterControls.Jump.canceled += OnJump;
    }

    private void Start()
    {
        _characterController.Move(_appliedMovement * Time.deltaTime);
    }

    private void Update()
    {
        _rotationHandler.HandleRotation(this);
        _currentState.UpdateStates();
        _characterController.Move(_appliedMovement * Time.deltaTime);
    }

    /*private void OnMovementInput(InputAction.CallbackContext context)
    {
        //_currentMovementInput = context.ReadValue<Vector2>();
        _currentMovementInput = _playerInputReader.movementInput;
        _isMovementPressed = _currentMovementInput.x != 0;
    }
    
    private void OnJump(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValueAsButton();
        _requireNewJumpPress = false;
    }*/

    // private void OnEnable()
    // {
    //     _playerInput.CharacterControls.Enable();
    // }
    //
    // private void OnDisable()
    // {
    //     _playerInput.CharacterControls.Disable();
    // }
}
