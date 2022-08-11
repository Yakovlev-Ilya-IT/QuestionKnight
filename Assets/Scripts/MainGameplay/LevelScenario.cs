using System;

public class LevelScenario : IEnemyTargetSetter
{
    private EnemySpawner _enemySpawner;
    private EnemyWave _enemyWave;

    public Enemy CurrentEnemy { get; private set; }

    public event Action<IDamageable> NewEnemyTargetHasBeenSet;

    private PauseHandler _pauseHandler;

    public LevelScenario(EnemySpawner enemySpawner, EnemyWave enemyWave, PauseHandler pauseHandler)
    {
        _enemySpawner = enemySpawner;
        _enemySpawner.EnemyHasSpawned += OnEnemyHasSpawned;

        _enemyWave = enemyWave;
        _enemyWave.Init();

        _pauseHandler = pauseHandler;
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
        _pauseHandler.Add(CurrentEnemy);
        NewEnemyTargetHasBeenSet?.Invoke(CurrentEnemy);
    }

    public void Recycle()
    {
        _pauseHandler.Remove(CurrentEnemy);
        CurrentEnemy = null;
    }

    ~LevelScenario()
    {
        _enemySpawner.EnemyHasSpawned -= OnEnemyHasSpawned;
    }
}
