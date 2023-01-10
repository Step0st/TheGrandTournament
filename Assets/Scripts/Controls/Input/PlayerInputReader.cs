using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader //можно сделать синглтон
{
    private PlayerInput _playerInput;
    private Vector2 _movementInput;
    private bool _isJumpPressed;
    private bool _isMovementPressed;
    public Action<Vector2, bool> OnMoving; 
    public Action<bool> OnJumpPressed;
    private PlayerInput.ICharacterControlsActions _characterControlsActionsImplementation;

    public PlayerInputReader()
    {
        _playerInput = new PlayerInput();
        _playerInput.CharacterControls.Enable();
        _playerInput.CharacterControls.Move.started += OnMovementInput;
        _playerInput.CharacterControls.Move.canceled += OnMovementInput;
        _playerInput.CharacterControls.Move.performed += OnMovementInput;
        _playerInput.CharacterControls.Jump.started += OnJump;
        _playerInput.CharacterControls.Jump.canceled += OnJump;
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
        _isMovementPressed = _movementInput.x != 0;
        OnMoving?.Invoke(_movementInput, _isMovementPressed);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValueAsButton();
        OnJumpPressed?.Invoke(_isJumpPressed);
    }
}