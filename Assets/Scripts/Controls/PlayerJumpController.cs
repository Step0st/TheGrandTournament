public class PlayerJumpController
{
    private PlayerInputReader _playerInputReader;
    
    public PlayerJumpController(PlayerInputReader playerInputReader)
    {
        _playerInputReader = playerInputReader;
        _playerInputReader.OnJumpPressed += (jumpButtonPressed) =>
        {
            _isJumpPressed = jumpButtonPressed;
            _requireNewJumpPress = false;
        };
    }
    
    private bool _isJumpPressed;
    private bool _requireNewJumpPress = false;
    
    public bool IsJumpPressed => _isJumpPressed;
    public bool RequireNewJumpPress { get { return _requireNewJumpPress;} set { _requireNewJumpPress = value; }}
    
    
}