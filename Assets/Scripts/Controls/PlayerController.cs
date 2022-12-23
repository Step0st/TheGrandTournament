using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInputReader _playerInputReader;
    private CharacterController _characterController;
    private Animator _animator;
    private RotationHandler _rotationHandler;
    private MovementHandler _movementHandler;
    private GravityHandler _gravityHandler;
    private PlayerBaseState _currentState;
    private PlayerStateFactory _states;
    
    private int _isMovingHash;
    private int _isJumpingHash;
    
    private Vector2 _currentMovementInput;
    private Vector3 _currentMovement;
    private Vector3 _appliedMovement;
    
    [SerializeField] private float _rotationPerFrame = 20f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _maxJumpHeight = 4.0f;
    [SerializeField] private float _maxJumpTime = 0.5f;
    private float _gravity = -9.8f;

    private bool _isJumpPressed;
    private bool _isMovementPressed;
    private bool _requireNewJumpPress = false;

    //getters and setters
    public CharacterController CharacterController { get { return _characterController; }} 
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; }} 
    public Animator Animator { get { return _animator;}}
    public RotationHandler RotationHandler { get { return _rotationHandler;}}
    public MovementHandler MovementHandler { get { return _movementHandler;}}
    public GravityHandler GravityHandler { get { return _gravityHandler;}}
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
    public float AppliedMovementY { get { return _appliedMovement.y;} set { _appliedMovement.y = value; }}
    public float AppliedMovementX { get { return _appliedMovement.x;} set { _appliedMovement.x = value; }}
    

    private void Awake()
    {
        _playerInputReader = new PlayerInputReader();
        _playerInputReader.Initialize();
        _rotationHandler = new RotationHandler();
        _movementHandler = new MovementHandler();
        _gravityHandler = new GravityHandler();
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
    }

    private void Update()
    {
        _currentState.UpdateStates();
    }

}
