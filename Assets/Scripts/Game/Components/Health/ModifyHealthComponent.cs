using UnityEngine;

public class ModifyHealthComponent : MonoBehaviour
{
    [SerializeField] private int _hpDelta;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<PlayerComponent>(out var playerComponent))
            {
                playerComponent.HealthComponent.ModifyHealth(_hpDelta);
            }
        }
    }
}


