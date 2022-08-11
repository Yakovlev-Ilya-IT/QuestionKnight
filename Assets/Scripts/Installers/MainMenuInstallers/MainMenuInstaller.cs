using Zenject;
using UnityEngine;

public class MainMenuInstaller : MonoInstaller
{
    [SerializeField] private SceneLoadMediator _sceneLoadMediator;
    [SerializeField] private SceneFader _sceneFader;

    public override void InstallBindings()
    {
        BindSceneLoader();
        BindMediator();
    }

    private void BindMediator()
    {
        Container.Bind<ISceneLoadMediator>().To<SceneLoadMediator>().FromInstance(_sceneLoadMediator).AsSingle();
    }

    private void BindSceneLoader()
    {
        Container.Bind<SceneFader>().FromInstance(_sceneFader).AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().FromNew().AsSingle();
    }
}