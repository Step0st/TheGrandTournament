using UnityEngine;

public class PlayerMovingState : PlayerBaseState
{
    public PlayerMovingState(PlayerController currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) {}
    
    public override void EnterState()
    {
        Ctx.Animator.SetBool(Ctx.IsMovingHash, true);
    }

    public override void UpdateState()
    {
        Ctx.AppliedMovementX = Ctx.CurrentMovementInput.x * Ctx.Speed;
        CheckSwitchStates();
    }

    public override void ExitState()
    {
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
