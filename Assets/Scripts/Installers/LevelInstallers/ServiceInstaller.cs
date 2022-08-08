using Zenject;
using UnityEngine;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private GameplayMediator _gameplaMediator;
    [SerializeField] private SceneLoadMediator _sceneLoadMediator;

    public override void InstallBindings()
    {
        BindDataProviders();
        BindMediator();
        BindSaver();
    }

    private void BindMediator()
    {
        Container.BindInterfacesAndSelfTo<GameplayMediator>().FromInstance(_gameplaMediator).AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoadMediator>().FromInstance(_sceneLoadMediator).AsSingle();
    }

    private void BindSaver()
    {
        Container.Bind<LevelSaver>().FromNew().AsSingle();
    }

    private void BindDataProviders()
    {
        Container.Bind<LevelsDataProvider>().FromNew().AsSingle();
        Container.Bind<NextLevelHandler>().FromNew().AsSingle();
    }
}
