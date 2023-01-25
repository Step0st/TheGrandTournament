using System;
using UnityEngine;

public class HudController : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private GameSession _session;

    private void Start()
    {
        _session = FindObjectOfType<GameSession>();
        _session.Data.Hp.OnChanged += OnHealthChanged;
        OnHealthChanged(_session.Data.Hp.Value, 0);
    }

    private void OnHealthChanged(int newvalue, int oldvalue)
    {
        //var maxHealth = DefsFacade.Instance.Player.MaxHealth;
        //var value = newvalue;
        _healthBar.SetHealth(newvalue);
    }

    private void OnDestroy()
    {
        _session.Data.Hp.OnChanged -= OnHealthChanged;
    }
}