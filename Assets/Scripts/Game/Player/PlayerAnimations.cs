using UnityEngine;

public class PlayerAnimations
{
    public PlayerAnimations()
    {
        _isJumpingHash = Animator.StringToHash("IsJumping");
        _isMovingHash = Animator.StringToHash("IsMoving");
    }
    
    private int _isJumpingHash;
    private int _isMovingHash;
    
    public int IsJumpingHash { get { return _isJumpingHash;}}
    public int IsMovingHash { get { return _isMovingHash;}}
}
