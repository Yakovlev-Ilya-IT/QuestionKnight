using System;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;

    public event Action<Enemy> EnemyHasSpawned;

    private DiContainer _diContainer;

    [Inject]
    public void Init(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public void Spawn(EnemySpawnItem enemySpawnItem)
    {
        Enemy enemy = enemySpawnItem.Factory.Get(enemySpawnItem.Type, _diContainer);
        enemy.SpawnTo(_spawnPoint.position);

        EnemyHasSpawned(enemy);
    }
}
