using Zenject;
using UnityEngine;

public class LevelSelectionInstaller : MonoInstaller
{
    [SerializeField] private SceneLoadMediator _sceneLoadMediator;
    [SerializeField] private LevelSelectionMediator _levelSelectionMediator;

    public override void InstallBindings()
    {
        Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle().NonLazy();
        Container.Bind<ISaver>().To<JsonSaver>().AsSingle();
        Container.Bind<LevelsDataProvider>().AsSingle();
        Container.Bind<AdventuresDataProvider>().AsSingle();
        Container.Bind<ISceneLoadMediator>().To<SceneLoadMediator>().FromInstance(_sceneLoadMediator).AsSingle();
        Container.Bind<ILevelSelectionMediator>().To<LevelSelectionMediator>().FromInstance(_levelSelectionMediator).AsSingle();
    }
}