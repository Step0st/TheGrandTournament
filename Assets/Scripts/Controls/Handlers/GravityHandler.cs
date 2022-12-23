using UnityEngine;

public class GravityHandler
{
    public void HandleGroundedGravity(PlayerController player)
    {
        player.CurrentMovementY = player.Gravity;
        player.AppliedMovementY = player.Gravity; 
    }
    
    public void HandleFallGravity(PlayerController player)
    {
        float previousYVelocity = player.CurrentMovementY;
        player.CurrentMovementY += player.Gravity * Time.deltaTime;
        player.AppliedMovementY = Mathf.Max((previousYVelocity + player.CurrentMovementY) * 0.5f, -20f);
    }
    
    public void HandleJumpGravity(PlayerController player)
    {
        bool isFalling = player.CurrentMovementY <= 0.0f || !player.IsJumpPressed;
        float fallMultiplier = 2.0f;

        if (isFalling)
        {
            float previousYVelocity = player.CurrentMovementY;
            player.CurrentMovementY += (player.Gravity * fallMultiplier * Time.deltaTime);
            player.AppliedMovementY = Mathf.Max((previousYVelocity + player.CurrentMovementY) * 0.5f, -20.0f);
        }
        else
        {
            float previousYVelocity = player.CurrentMovementY;
            player.CurrentMovementY += (player.Gravity * Time.deltaTime);
            player.AppliedMovementY = (previousYVelocity + player.CurrentMovementY) * 0.5f;
        }
    }
    
}