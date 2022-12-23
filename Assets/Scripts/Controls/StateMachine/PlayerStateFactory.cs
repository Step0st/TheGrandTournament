using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class PlayerStateFactory
{
    private PlayerController _context;
    private Dictionary<PlayerStates, PlayerBaseState> _states = new Dictionary<PlayerStates, PlayerBaseState>();
    
    public PlayerStateFactory(PlayerController currentContext)
    {
        _context = currentContext;
        _states[PlayerStates.idle] = new PlayerIdleState(_context, this);
        _states[PlayerStates.moving] = new PlayerMovingState(_context, this);
        _states[PlayerStates.grounded] = new PlayerGroundedState(_context, this); 
        _states[PlayerStates.jump] =  new PlayerJumpState(_context, this);
        _states[PlayerStates.fall] = new PlayerFallState(_context, this);
    }

    public PlayerBaseState Idle()
    {
        return _states[PlayerStates.idle];
    }

    public PlayerBaseState Moving()
    {
        return _states[PlayerStates.moving];
    }

    public PlayerBaseState Jump()
    {
        return _states[PlayerStates.jump];
    }

    public PlayerBaseState Grounded()
    {
        return _states[PlayerStates.grounded];
    }

    public PlayerBaseState Fall()
    {
        return _states[PlayerStates.fall];
    }
}

enum PlayerStates
{
    grounded,
    jump,
    fall,
    moving,
    idle
}


