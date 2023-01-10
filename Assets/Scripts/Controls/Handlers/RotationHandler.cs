using UnityEngine;

public class RotationHandler
{
    public void HandleRotation(PlayerController player)
    {
        Vector3 positionToLookAt = new Vector3(player.PlayerMovementController.CurrentMovementInput.x,0,0);
        Quaternion currentRotation = player.transform.rotation;
        if (player.PlayerMovementController.IsMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            player.transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, player.RotationPerFrame*Time.deltaTime);
        }
    }
}