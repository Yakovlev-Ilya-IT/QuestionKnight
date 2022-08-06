using UnityEngine;
using Zenject;

public class EnemySpawnSystemInstaller : MonoInstaller
{
    [SerializeField] private EnemySpawner _enemySpawner;

    public override void InstallBindings()
    {
        BindScenario();
        BindSpawnSystem();
    }

    private void BindScenario()
    {
        Container.BindInterfacesAndSelfTo<LevelScenario>().AsSingle();
    }

    private void BindSpawnSystem()
    {
        Container.Bind<EnemySpawner>().FromInstance(_enemySpawner).AsSingle();
    }
}