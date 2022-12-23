using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    private PlayerInput _playerInput;
    public Vector2 movementInput;
    public bool isJumpPressed;
    public bool isMovementPressed;
    public Action<Vector2, bool> OnMoving;
    public Action<bool> OnJumpPressed;
    //public Action<bool> OnMovementPressed;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.CharacterControls.Move.started += OnMovementInput;
        _playerInput.CharacterControls.Move.canceled += OnMovementInput;
        _playerInput.CharacterControls.Move.performed += OnMovementInput;
        _playerInput.CharacterControls.Jump.started += OnJump;
        _playerInput.CharacterControls.Jump.canceled += OnJump;
    }

    public void OnMovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        isMovementPressed = movementInput.x != 0;
        OnMoving?.Invoke(movementInput, isMovementPressed);
    }   
    
    private void OnJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
        OnJumpPressed?.Invoke(isJumpPressed);
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