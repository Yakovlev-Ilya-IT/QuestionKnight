using Zenject;
using UnityEngine;

public class LevelSelectionInstaller : MonoInstaller
{
    [SerializeField] private SceneLoadMediator _sceneLoadMediator;
    [SerializeField] private LevelSelectionMediator _levelSelectionMediator;
    [SerializeField] private SceneFader _sceneFader;

    public override void InstallBindings()
    {
        BindSceneLoader();
        BindDataProviders();
        BindMediator();
    }

    private void BindDataProviders()
    {
        Container.Bind<LevelsDataProvider>().AsSingle();
        Container.Bind<AdventuresDataProvider>().AsSingle();
    }

    private void BindMediator()
    {
        Container.Bind<ISceneLoadMediator>().To<SceneLoadMediator>().FromInstance(_sceneLoadMediator).AsSingle();
        Container.Bind<ILevelSelectionMediator>().To<LevelSelectionMediator>().FromInstance(_levelSelectionMediator).AsSingle();
    }

    private void BindSceneLoader()
    {
        Container.Bind<SceneFader>().FromInstance(_sceneFader).AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().FromNew().AsSingle();
    }
}