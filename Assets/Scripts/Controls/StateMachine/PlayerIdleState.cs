using System;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerController currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) {}
    
    public override void EnterState()
    {
        Ctx.Animator.SetBool(Ctx.PlayerAnimations.IsMovingHash, false);
        Ctx.Animator.SetBool(Ctx.PlayerAnimations.IsJumpingHash, false);
        Ctx.PlayerMovementController.AppliedMovementX = 0;
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void ExitState()
    {
    }

    public override void CheckSwitchStates()
    {
        if (Ctx.PlayerMovementController.IsMovementPressed)
        {
            SwitchState(Factory.Moving());
        }
    }

    public override void InitializeSubState()
    {

    }
}
