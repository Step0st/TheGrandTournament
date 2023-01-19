public class PlayerMovingState : PlayerBaseState
{
    public PlayerMovingState(PlayerController currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) {}
    
    public override void EnterState()
    {
        Ctx.Animator.SetBool(Ctx.PlayerAnimations.IsMovingHash, true);
    }

    public override void UpdateState()
    {
        Ctx.PlayerMovementController.AppliedMovementX = Ctx.PlayerMovementController.CurrentMovementInput.x * Ctx.Speed;
        CheckSwitchStates();
    }

    public override void ExitState()
    {
    }

    public override void CheckSwitchStates()
    {
        if (!Ctx.PlayerMovementController.IsMovementPressed)
        {
            SwitchState(Factory.Idle());
        }
    }

    public override void InitializeSubState()
    {
    }
}
