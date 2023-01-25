using System;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public Action OnDeath;
    public Action OnDamaged;
    private GameSession _session;
    private HealthComponent _healthComponent;
    private ReloadLevelComponent _reloadLevelComponent;
    [Header("Equipment")]
    [SerializeField] private GameObject _weapon;
    [SerializeField] private GameObject _shield;
    
    public HealthComponent HealthComponent { get { return _healthComponent;}}

    private void Start()
    {
        _session = FindObjectOfType<GameSession>();
        _reloadLevelComponent = GetComponent<ReloadLevelComponent>();
        
        _healthComponent = new HealthComponent();
        _healthComponent.SetHealth(_session.Data.Hp.Value);
        _healthComponent.OnChange += OnHealthChanged;
        _healthComponent.OnDamage += TakeDamage;
        _healthComponent.OnDie += Death;

        if (_session.Data.isArmed)
        {
            _weapon.SetActive(true);
            _shield.SetActive(true);
        }
    }

    private void OnHealthChanged(int currentHealth)
    {
        _session.Data.Hp.Value = currentHealth;
    }

    private void Attack()
    {
        if (_session.Data.isArmed)
        {
            //ATTACK code
        }
    }

    private void ArmHero()
    {
        _session.Data.isArmed = true;
        // code to add weapons
    }
    
    public void TakeDamage()
    {
        OnDamaged?.Invoke();
    }

    public void Death()
    {
        OnDeath?.Invoke();
        //_reloadLevelComponent.Reload();
    }

    public void TeleportTo(Vector3 position)
    {
        transform.position = position;
    }

    private void OnDisable()
    {
        _healthComponent.OnChange -= OnHealthChanged;
        _healthComponent.OnDamage -= TakeDamage;
        _healthComponent.OnDie -= Death;
    }
}