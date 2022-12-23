using UnityEngine;

public class RotationHandler
{
    public void HandleRotation(PlayerStateMachine player)
    {
        Vector3 positionToLookAt = new Vector3(player.CurrentMovementInput.x,0,0);
        Quaternion currentRotation = player.transform.rotation;
        if (player.IsMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            player.transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, player.RotationPerFrame*Time.deltaTime);
        }
    }
}