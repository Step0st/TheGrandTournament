using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAnMovController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private CharacterController _characterController;
    private Animator _animator;
    private int isMovingHash;
    private int isJumpingHash;
    private bool isJumpAnimating = false;

    private Vector2 currentMovementInput;
    private Vector3 currentMovement;
    private Vector3 appliedMovement;
    private bool isMovementPressed;
    [SerializeField] private float rotationPerFrame = 20f;
    [SerializeField] private float speed = 5f;

    private float gravity = -9.8f;
    private float groundedGravity = -0.05f;

    private bool isJumpPressed = false;
    private float initialJumpVelocity;
    [SerializeField] private float maxJumpHeight = 4.0f;
    [SerializeField] private float maxJumpTime = 0.5f;


    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        isMovingHash = Animator.StringToHash("IsMoving");
        isJumpingHash = Animator.StringToHash("IsJumping");

        _playerInput.CharacterControls.Move.started += OnMovementInput;
        _playerInput.CharacterControls.Move.canceled += OnMovementInput;
        _playerInput.CharacterControls.Move.performed += OnMovementInput;
        _playerInput.CharacterControls.Jump.started += OnJump;
        _playerInput.CharacterControls.Jump.canceled += OnJump;
        
        SetupJumpVariables();
    }

    private void SetupJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x * speed;
        isMovementPressed = currentMovement.x != 0;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
    }

    private void Update()
    {
        HandleAnimation();
        HandleRotation();
        Debug.Log("grounded " + _characterController.isGrounded);
        appliedMovement.x = currentMovement.x;
        _characterController.Move(appliedMovement * Time.deltaTime);
        
        HandleGravity();
        HandleJump();
    }

    private void HandleAnimation()
    {
        bool isMoving = _animator.GetBool(isMovingHash);
        if (isMovementPressed && !isMoving)
        {
            _animator.SetBool(isMovingHash, true);
        }
        else if (!isMovementPressed)
        {
            _animator.SetBool(isMovingHash, false);
        }
    }

    private void HandleRotation()
    {
        Vector3 positionToLookAt = new Vector3(currentMovement.x, 0,0);
        Quaternion currentRotation = transform.rotation;
        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationPerFrame*Time.deltaTime);
        }
    }

    private void HandleGravity()
    {
        bool isFalling = currentMovement.y <= 0.0f || !isJumpPressed;
        float fallMultiplier = 2.0f;
        if (_characterController.isGrounded)
        {
            if (isJumpAnimating)
            {
                _animator.SetBool(isJumpingHash, false);
                isJumpAnimating = false;
            }
            currentMovement.y = groundedGravity;
            appliedMovement.y = groundedGravity;
        }
        else if (isFalling)
        {
            float previousYVelocity = currentMovement.y;
            currentMovement.y += (gravity * fallMultiplier * Time.deltaTime);
            appliedMovement.y = Mathf.Max((previousYVelocity + currentMovement.y) * 0.5f, -20.0f);
        }
        else
        {
            float previousYVelocity = currentMovement.y;
            currentMovement.y += (gravity * Time.deltaTime);
            appliedMovement.y = (previousYVelocity + currentMovement.y) * 0.5f;
        }
    }

    private void HandleJump()
    {
        if (/* !isJumping && */ _characterController.isGrounded && isJumpPressed)
        {
            //isJumping = true;
            _animator.SetBool(isJumpingHash, true);
            isJumpAnimating = true;
            currentMovement.y = initialJumpVelocity;
            appliedMovement.y = initialJumpVelocity;
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
