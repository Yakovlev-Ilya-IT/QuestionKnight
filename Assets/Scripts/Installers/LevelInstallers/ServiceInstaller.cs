using Zenject;
using UnityEngine;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private GameplayMediator _gameplaMediator;
    [SerializeField] private SceneLoadMediator _sceneLoadMediator;
    [SerializeField] private SceneFader _sceneFader;
    public override void InstallBindings()
    {
        BindSceneLoader();
        BindPauseHandler();
        BindDataProviders();
        BindMediator();
        BindSaver();
    }

    private void BindPauseHandler()
    {
        Container.BindInterfacesAndSelfTo<PauseHandler>().FromNew().AsSingle();
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

    private void BindSceneLoader()
    {
        Container.Bind<SceneFader>().FromInstance(_sceneFader).AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().FromNew().AsSingle();
    }
}
