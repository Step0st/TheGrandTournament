public class PlayerDamageController
{

    public PlayerDamageController(PlayerComponent _playerComponent)
    {
        _playerComponent.OnDamaged += () =>
        {
            _isDamaged = true;
        };
    }
    
    private bool _isDamaged;
    
    public bool IsDamaged { get { return _isDamaged;} set { _isDamaged = value; }}
    
}