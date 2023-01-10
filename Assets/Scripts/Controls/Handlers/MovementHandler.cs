using UnityEngine;

public class MovementHandler
{
    public void HandleMovement(PlayerController player)
    {
        player.CharacterController.Move(new Vector3(player.PlayerMovementController.AppliedMovementX, 
            player.PlayerMovementController.AppliedMovementY,0) * Time.deltaTime);  
    }
    
}