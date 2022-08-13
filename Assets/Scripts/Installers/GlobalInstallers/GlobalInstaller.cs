using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
        BindSaver();
        BindLoader();
    }

    private void BindInput()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Container.BindInterfacesAndSelfTo<MobileInput>().AsSingle();
        }
        else
        {
            Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        }
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
