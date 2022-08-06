using Zenject;
using UnityEngine;
using System;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private GameplayMediator _gameplaMediator;
    [SerializeField] private SceneLoadMediator _sceneLoadMediator;
    private LevelsDataProvider _levelsDataProvider;

    public override void InstallBindings()
    {
        BindMediator();
        BindSaver();
        BindLoader();
        BindLevelsDataProvider();
    }

    private void BindMediator()
    {
        Container.BindInterfacesAndSelfTo<GameplayMediator>().FromInstance(_gameplaMediator).AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoadMediator>().FromInstance(_sceneLoadMediator).AsSingle();
    }

    private void BindSaver()
    {
        Container.Bind<ISaver>().To<JsonSaver>().FromNew().AsSingle();
        Container.Bind<LevelSaver>().FromNew().AsSingle();
    }

    private void BindLoader()
    {
        Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().FromNew().AsSingle();
    }

    private void BindLevelsDataProvider()
    {
        Container.Bind<LevelsDataProvider>().FromNew().AsSingle();
    }
}
