using UnityEngine;

public class PlayerFallState : PlayerBaseState, IGravityHandler, IRotationHandler, IMovementHandler
{
    public PlayerFallState(PlayerController currentContext, PlayerStateFactory playerStateFactory) 
        : base(currentContext, playerStateFactory)
    {
        IsRootState = true;
    }

    public override void EnterState()
    {
        InitializeSubState();
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

    public void HandleGravity()
    {
        Ctx.GravityHandler.HandleFallGravity(Ctx);
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
