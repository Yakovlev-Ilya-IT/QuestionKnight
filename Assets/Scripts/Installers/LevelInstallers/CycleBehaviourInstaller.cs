using Zenject;

public class CycleBehaviourInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindLevelCycle();
    }

    private void BindLevelCycle()
    {
        Container.BindInterfacesAndSelfTo<LevelCycleBehaviour>().AsSingle().NonLazy();
    }
}