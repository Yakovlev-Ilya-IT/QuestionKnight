using Zenject;

public class LevelSelectionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SceneLoader>().AsSingle();
        Container.Bind<SelectedLevelLoader>().AsSingle().NonLazy();
    }
}