using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private PlayerComponent _playerComponent;
    private Animator _animator;
    private RotationHandler _rotationHandler;
    private MovementHandler _movementHandler;
    private GravityHandler _gravityHandler;
    private PlayerBaseState _currentState;
    private PlayerStateFactory _states;
    [Inject] private PlayerJumpController _playerJumpController;
    [Inject] private PlayerMovementController _playerMovementController;
    private PlayerDamageController _playerDamageController;
    [Inject] private PlayerAnimations _playerAnimations;
    //[Inject] private PlayerInputReader _playerInputReader;

    [SerializeField] private float _rotationPerFrame = 20f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _maxJumpHeight = 4.0f;
    [SerializeField] private float _maxJumpTime = 0.5f;
    private float _gravity = -9.8f;
    private bool _isSecondJumpAllowed;
    private GameSession _gameSession;

    //getters and setters
    public CharacterController CharacterController { get { return _characterController; }}
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; }} 
    public Animator Animator { get { return _animator;}}
    public RotationHandler RotationHandler { get { return _rotationHandler;}}
    public MovementHandler MovementHandler { get { return _movementHandler;}}
    public GravityHandler GravityHandler { get { return _gravityHandler;}}
    public PlayerJumpController PlayerJumpController { get { return _playerJumpController;}}
    public PlayerMovementController PlayerMovementController { get { return _playerMovementController;}}
    public PlayerDamageController PlayerDamageController { get { return _playerDamageController;}}
    public PlayerAnimations PlayerAnimations { get { return _playerAnimations;}}
    public float Gravity { get { return _gravity;} set{ _gravity = value;}}
    public float Speed { get { return _speed;}}
    public float RotationPerFrame { get { return _rotationPerFrame;}}
    public float MaxJumpHeight { get { return _maxJumpHeight;}}
    public float MaxJumpTime { get { return _maxJumpTime;}}
    public bool IsSecondJumpAllowed { get { return _isSecondJumpAllowed;}}

    
    private void Awake()
    {
        _rotationHandler = new RotationHandler();
        _movementHandler = new MovementHandler();
        _gravityHandler = new GravityHandler();
        //_playerJumpController = new PlayerJumpController(_playerInputReader);
        //_playerMovementController = new PlayerMovementController(_playerInputReader);
        //_playerAnimations = new PlayerAnimations();
        _characterController = GetComponent<CharacterController>();
        
        _playerComponent = GetComponent<PlayerComponent>();
        _playerDamageController = new PlayerDamageController(_playerComponent);
        
        _animator = GetComponent<Animator>();

        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();
        
        _gameSession = FindObjectOfType<GameSession>();
        if (_gameSession.Data.isDoubleJumpBoots)
        {
            _isSecondJumpAllowed = true;
        }
    }

    private void Update()
    {
        _currentState.UpdateStates(); ;
    }
}
