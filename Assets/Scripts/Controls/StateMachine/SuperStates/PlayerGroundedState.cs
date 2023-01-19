using System;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState, IGravityHandler, IRotationHandler, IMovementHandler
{
    public PlayerGroundedState(PlayerController currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {
        IsRootState = true;
    }
    
    public override void EnterState()
    {
        InitializeSubState();
        HandleGravity();
    }

    public override void UpdateState()
    {
        HandleMovement();
        HandleRotation();
        CheckSwitchStates();
    }

    public override void ExitState()
    {

    }

    public override void CheckSwitchStates()
    {
        if (Ctx.PlayerJumpController.IsJumpPressed && !Ctx.PlayerJumpController.RequireNewJumpPress)
        {
            SwitchState(Factory.Jump());
        }
        
        if (!Ctx.CharacterController.isGrounded)
        {
            SwitchState(Factory.Fall());
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

    public void HandleGravity()
    {
        Ctx.GravityHandler.HandleGroundedGravity(Ctx);
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