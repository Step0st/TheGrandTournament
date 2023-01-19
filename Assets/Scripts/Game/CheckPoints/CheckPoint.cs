using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Action OnCheckPointReached;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCheckPointReached?.Invoke();
        }
    }
}

