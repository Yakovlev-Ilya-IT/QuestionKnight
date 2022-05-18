using System;
using UnityEngine;

public class GameScenario : IEnemyTargetSetter
{
    private EnemySpawner _enemySpawner;
    private EnemyWave _enemyWave;

    public Enemy CurrentEnemy { get; private set; }

    public event Action<IDamageable> NewEnemyTargetHasBeenSet;

    public GameScenario(EnemySpawner enemySpawner, EnemyWave enemyWave)
    {
        _enemySpawner = enemySpawner;
        _enemySpawner.EnemyHasSpawned += OnEnemyHasSpawned;

        _enemyWave = enemyWave;
        _enemyWave.Init();
    }

    public bool TryIncreaseProgress()
    {
        if(CurrentEnemy == null)
        {
            if (_enemyWave.TryGetNextSpawnItem(out EnemySpawnItem spawnItem))
            {
                _enemySpawner.Spawn(spawnItem);

                NewEnemyTargetHasBeenSet?.Invoke(CurrentEnemy);

                return true;
            }

            return false;
        }

        return true;
    } 

    public void OnEnemyHasSpawned(Enemy enemy)
    {
        CurrentEnemy = enemy;
        NewEnemyTargetHasBeenSet?.Invoke(CurrentEnemy);
    }

    ~GameScenario()
    {
        _enemySpawner.EnemyHasSpawned -= OnEnemyHasSpawned;
    }

    public void Recycle()
    {
        CurrentEnemy = null; 
    }
}
