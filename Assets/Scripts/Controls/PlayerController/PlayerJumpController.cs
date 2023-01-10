public class PlayerJumpController
{
    public PlayerJumpController()
    {
        _playerInputReader = new PlayerInputReader();
        _playerInputReader.OnJumpPressed += (jumpButtonPressed) =>
        {
            _isJumpPressed = jumpButtonPressed;
            _requireNewJumpPress = false;
        };
    }
    
    private PlayerInputReader _playerInputReader;
    

    private bool _isJumpPressed;
    private bool _requireNewJumpPress = false;
    
    public bool IsJumpPressed { get { return _isJumpPressed;}}
    public bool RequireNewJumpPress { get { return _requireNewJumpPress;} set { _requireNewJumpPress = value; }}
    
    
}