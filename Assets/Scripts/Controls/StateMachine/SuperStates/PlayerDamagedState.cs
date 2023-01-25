using UnityEngine;

public class PlayerDamagedState : PlayerBaseState, IGravityHandler, IRotationHandler, IMovementHandler
{
    public PlayerDamagedState(PlayerController currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {
        IsRootState = true;
    }
    
    public override void EnterState()
    {
        InitializeSubState();
        HandleDamage();
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
    }

    public override void CheckSwitchStates()
    {
        if (Ctx.CharacterController.isGrounded)
        {
            SwitchState(Factory.Grounded());
            Ctx.PlayerDamageController.IsDamaged = false;
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

    private void HandleDamage()
    {
        float initialJumpVelocity = 4 * Ctx.MaxJumpHeight / Ctx.MaxJumpTime;
        Ctx.Animator.SetBool(Ctx.PlayerAnimations.IsJumpingHash, true);
        Ctx.PlayerMovementController.CurrentMovementY = initialJumpVelocity;
        Ctx.PlayerMovementController.AppliedMovementY = initialJumpVelocity;
        Ctx.Gravity = (-2 * Ctx.MaxJumpHeight) / Mathf.Pow(Ctx.MaxJumpTime/2, 2);
    }

    public void HandleGravity()
    {
        Ctx.GravityHandler.HandleDamagedGravity(Ctx);
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