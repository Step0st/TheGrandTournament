using System;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState, IGravityHandler, IRotationHandler, IMovementHandler
{
    public PlayerJumpState(PlayerController currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {
        IsRootState = true;
    }
    
    public override void EnterState()
    {
        InitializeSubState();
        HandleJump();
    }

    public override void UpdateState()
    {
        HandleGravity();
        HandleMovement();
        HandleRotation();
        CheckSwitchStates();
    }

    public override void ExitState()
    {
        Ctx.Animator.SetBool(Ctx.PlayerAnimations.IsJumpingHash, false);
        if (Ctx.PlayerJumpController.IsJumpPressed)
        {
            Ctx.PlayerJumpController.RequireNewJumpPress = true;
        }
    }

    public override void CheckSwitchStates()
    {
        if (Ctx.CharacterController.isGrounded)
        {
            SwitchState(Factory.Grounded());
        }
    }

    public override void InitializeSubState()
    {
        if (Ctx.PlayerMovementController.IsMovementPressed)
        {
            SetSubState(Factory.Moving());
        }
        else
        {
            SetSubState(Factory.Idle());
        }
    }

    private void HandleJump()
    {
        float initialJumpVelocity = 4 * Ctx.MaxJumpHeight / Ctx.MaxJumpTime;
        Ctx.Animator.SetBool(Ctx.PlayerAnimations.IsJumpingHash, true);
        Ctx.PlayerMovementController.CurrentMovementY = initialJumpVelocity;
        Ctx.PlayerMovementController.AppliedMovementY = initialJumpVelocity;
        Ctx.Gravity = (-2 * Ctx.MaxJumpHeight) / Mathf.Pow(Ctx.MaxJumpTime/2, 2);
    }

    public void HandleGravity()
    {
        Ctx.GravityHandler.HandleJumpGravity(Ctx);
    }
    
    public void HandleRotation()
    {
        Ctx.RotationHandler.HandleRotation(Ctx);
    }
    
    public void HandleMovement()
    {
        Ctx.MovementHandler.HandleMovement(Ctx);
    }
}
