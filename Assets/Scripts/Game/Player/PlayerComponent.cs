using System;
using System.Collections;
using UnityEngine;

public class PlayerComponent : MonoBehaviour, ICanDie
{
    public Action OnDeath;
    
    public void Death()
    {
        OnDeath?.Invoke();
    }

    public void TeleportTo(Vector3 position)
    {
        transform.position = position;
    }
    
}