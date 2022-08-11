using Zenject;

public class Player : Character
{
    private IEnemyTargetSetter _enemyTargetSetter;
    private PauseHandler _pauseHandler;

    [Inject]
    public void Initialize(PlayerStatsConfig playerStatsConfig, IEnemyTargetSetter enemyTargetSetter, PauseHandler pauseHandler)
    {
        Initialize(playerStatsConfig.MaxHealth, playerStatsConfig.AttackDamage);
        _enemyTargetSetter = enemyTargetSetter;
        _enemyTargetSetter.NewEnemyTargetHasBeenSet += OnNewTargetHasBeenSpawned;

        _pauseHandler = pauseHandler;
        _pauseHandler.Add(this);
    }

    public void OnNewTargetHasBeenSpawned(IDamageable target)
    {
        _target = target;
    }

    protected override void OnDied()
    {
        base.OnDied();
        _pauseHandler.Remove(this);
    }

    private new void OnDisable()
    {
        base.OnDisable();
        _enemyTargetSetter.NewEnemyTargetHasBeenSet -= OnNewTargetHasBeenSpawned;
    }
}
