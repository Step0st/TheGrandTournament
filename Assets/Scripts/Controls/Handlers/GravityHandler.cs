using UnityEngine;

public class GravityHandler
{
    public void HandleGroundedGravity(PlayerController player)
    {
        player.PlayerMovementController.CurrentMovementY = player.Gravity; //ВЫНЕСТИ Gravity В КОНСТАНТЫ
        player.PlayerMovementController.AppliedMovementY = player.Gravity; 
    }
    
    public void HandleFallGravity(PlayerController player)
    {
        float previousYVelocity = player.PlayerMovementController.CurrentMovementY;
        player.PlayerMovementController.CurrentMovementY += player.Gravity * Time.deltaTime;
        player.PlayerMovementController.AppliedMovementY = Mathf.Max((previousYVelocity + player.PlayerMovementController.CurrentMovementY) * 0.5f, -20f); //ВЫНЕСТИ В ПРИВАТНЫЙ МЕТОД; УБРАТЬ МАГИЧЕСКИЕ ЦИФРЫ
    }
    
    public void HandleJumpGravity(PlayerController player)
    {
        bool isFalling = player.PlayerMovementController.CurrentMovementY <= 0.0f || !player.PlayerJumpController.IsJumpPressed; //should be set not here
        float fallMultiplier = 2.0f; //УБРАТЬ МАГИЧЕСКИЕ ЦИФРЫ

        if (isFalling)
        {
            float previousYVelocity = player.PlayerMovementController.CurrentMovementY;
            player.PlayerMovementController.CurrentMovementY += (player.Gravity * fallMultiplier * Time.deltaTime);
            player.PlayerMovementController.AppliedMovementY = Mathf.Max((previousYVelocity + player.PlayerMovementController.CurrentMovementY) * 0.5f, -20.0f);
        }
        else
        {
            float previousYVelocity = player.PlayerMovementController.CurrentMovementY;
            player.PlayerMovementController.CurrentMovementY += (player.Gravity * Time.deltaTime);
            player.PlayerMovementController.AppliedMovementY = (previousYVelocity + player.PlayerMovementController.CurrentMovementY) * 0.5f;
        }
    }
    
    
}