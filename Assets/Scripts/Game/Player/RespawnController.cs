using Game;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
        private CheckPointManager _checkPointManager;
        [SerializeField] private PlayerComponent _playerComponent;

        private void Awake()
        {
                _checkPointManager = GetComponent<CheckPointManager>();
                
                _playerComponent.OnDeath += () =>
                {
                        _playerComponent.TeleportTo(_checkPointManager.CurrentCheckPoint.transform.position);
                };
        }
}
