using Zenject;
using UnityEngine;
using System;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private GameplayMediator _gameplaMediator;
    [SerializeField] private SceneLoadMediator _sceneLoadMediator;
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private CristallSwipeHandler _cristallSwipeHandler;
    public override void InstallBindings()
    {
        BindSceneLoader();
        BindPauseHandler();
        BindDataProviders();
        BindMediator();
        BindSaver();
        BindCristallSwipeHandler();
    }

    private void BindCristallSwipeHandler()
    {
        Container.BindInterfacesAndSelfTo<CristallSwipeHandler>().FromInstance(_cristallSwipeHandler).AsSingle();
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
    }

    private void BindSceneLoader()
    {
        Container.Bind<SceneFader>().FromInstance(_sceneFader).AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().FromNew().AsSingle();
    }
}
