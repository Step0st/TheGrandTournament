using ModestTree;
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
        HandleSecondJump();
        CheckSwitchStates();
    }

    public override void ExitState()
    {
        Ctx.Animator.SetBool(Ctx.PlayerAnimations.IsJumpingHash, false);
        if (Ctx.PlayerJumpController.IsJumpPressed)
        {
            Ctx.PlayerJumpController.RequireNewJumpPress = true;
        }
        Ctx.PlayerJumpController.IsSecondJumpPerformed = false;
    }

    public override void CheckSwitchStates()
    {
        if (Ctx.CharacterController.isGrounded)
        {
            SwitchState(Factory.Grounded());
        }
        if (Ctx.PlayerDamageController.IsDamaged)
        {
            SwitchState(Factory.Damaged());
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
    
    private void HandleSecondJump()
    {
        if (!Ctx.PlayerJumpController.IsJumpPressed && !Ctx.PlayerJumpController.IsSecondJumpPerformed &&
            Ctx.IsSecondJumpAllowed)
        {
            Ctx.PlayerJumpController.IsReadyForSecondJump = true;
        }
        
        if (Ctx.PlayerJumpController.IsJumpPressed && Ctx.PlayerJumpController.IsReadyForSecondJump)
        {
            HandleJump();
            Ctx.PlayerJumpController.IsReadyForSecondJump = false;
            Ctx.PlayerJumpController.IsSecondJumpPerformed = true;
        }
        
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
