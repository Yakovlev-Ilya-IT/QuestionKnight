using UnityEngine;
using Zenject;

public class CristallInstaller : MonoInstaller
{
    [SerializeField] private Cristall _cristallPrefab;
    [SerializeField] private Transform _cristallSpawnPoint;

    public override void InstallBindings()
    {
        BindInstance();
    }

    private void BindInstance()
    {
        Cristall cristall = Container.InstantiatePrefabForComponent<Cristall>(_cristallPrefab, _cristallSpawnPoint.position, Quaternion.identity, null);
        Container.Bind<Cristall>().FromInstance(cristall).AsSingle().NonLazy();
    }
}