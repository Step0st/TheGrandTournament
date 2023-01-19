using UnityEngine;

public class PlayerMovementController
{
    private PlayerInputReader _playerInputReader;
    public PlayerMovementController(PlayerInputReader playerInputReader)
    {
        _playerInputReader = playerInputReader;
        _playerInputReader.OnMoving += (movementVector, movementButtonPressed) =>
        {
            _currentMovementInput = movementVector;
            _isMovementPressed = movementButtonPressed;
        };
    }
    
    private Vector2 _currentMovementInput;
    private Vector3 _currentMovement;
    private Vector3 _appliedMovement;
    private bool _isMovementPressed;
    
    public Vector2 CurrentMovementInput => _currentMovementInput;
    public bool IsMovementPressed => _isMovementPressed;
    public float CurrentMovementY { get { return _currentMovement.y;} set { _currentMovement.y = value; }}
    public float AppliedMovementY { get { return _appliedMovement.y;} set { _appliedMovement.y = value; }}
    public float AppliedMovementX { get { return _appliedMovement.x;} set { _appliedMovement.x = value; }}
}