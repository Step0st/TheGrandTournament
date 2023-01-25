using System;
using Game;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
        private ReloadLevelComponent _reloadLevelComponent;
        [SerializeField] private PlayerComponent _playerComponent;

        private void Awake()
        {
                _reloadLevelComponent = GetComponent<ReloadLevelComponent>();
                
                _playerComponent.OnDeath += () =>
                {
                        _reloadLevelComponent.Reload();
                };
        }

        private void OnDestroy()
        {
                _playerComponent.OnDeath -= () =>
                {
                        _reloadLevelComponent.Reload();
                };
        }
}
