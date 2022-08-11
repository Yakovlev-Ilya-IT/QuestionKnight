using System;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSaver();
        BindLoader();
    }

    private void BindSaver()
    {
        Container.Bind<ISaver>().To<JsonSaver>().FromNew().AsSingle();
    }

    private void BindLoader()
    {
        Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
    }
}
