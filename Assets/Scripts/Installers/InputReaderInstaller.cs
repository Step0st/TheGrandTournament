using Zenject;

public class InputReaderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerInputReader>().AsSingle().NonLazy();
        Container.Bind<PlayerMovementController>().AsSingle().NonLazy();
        Container.Bind<PlayerJumpController>().AsSingle().NonLazy();
        Container.Bind<PlayerAnimations>().AsSingle().NonLazy();
    }
}