using System;

public class HealthComponent 
{
    private int _health;
    public Action OnDamage;
    public Action OnHeal;
    public Action OnDie;
    public Action<int> OnChange;
    
    public void ModifyHealth(int healthDelta)
    {
        _health += healthDelta;
        OnChange?.Invoke(_health);

        if (healthDelta < 0)
        {
            OnDamage?.Invoke();
        }
        
        if (healthDelta > 0)
        {
            OnHeal?.Invoke();
        }
        
        if (_health <= 0)
        {
            OnDie?.Invoke();
        }
    }

    public void SetHealth(int health)
    {
        _health = health; 
    }
}