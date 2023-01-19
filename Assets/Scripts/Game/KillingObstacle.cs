using UnityEngine;

namespace Game
{
    public class KillingObstacle : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.TryGetComponent<PlayerComponent>(out var playerComponent))
                {
                    playerComponent.Death();
                }
            }
        }
    }
}

