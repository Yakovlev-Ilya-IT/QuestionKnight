using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindLevelCycle();
    }

    private void BindLevelCycle()
    {
        Container.Bind<IStationStateSwitcher>().To<LevelCycleBehaviour>().AsSingle().NonLazy();
    }
}