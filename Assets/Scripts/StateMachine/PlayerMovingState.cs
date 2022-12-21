public class PlayerMovingState : PlayerBaseState
{
    public PlayerMovingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) {}
    
    public override void EnterState()
    {
        Ctx.Animator.SetBool(Ctx.IsMovingHash, true);
    }

    public override void UpdateState()
    {
        Ctx.AppliedMovementX = Ctx.CurrentMovementInput.x;
        CheckSwitchStates();
    }

    public override void ExitState()
    {
        // if (!Ctx.IsMovementPressed)
        // {
        //     SetSubState(Factory.Idle());
        // };
    }

    public override void CheckSwitchStates()
    {
        if (!Ctx.IsMovementPressed)
        {
            SwitchState(Factory.Idle());
        }
    }

    public override void InitializeSubState()
    {
    }
}
