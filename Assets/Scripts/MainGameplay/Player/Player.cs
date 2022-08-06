using Zenject;

public class Player : Character
{
    private IEnemyTargetSetter _enemyTargetSetter;

    [Inject]
    public void Initialize(PlayerStatsConfig playerStatsConfig, IEnemyTargetSetter enemyTargetSetter)
    {
        Initialize(playerStatsConfig.MaxHealth, playerStatsConfig.AttackDamage);
        _enemyTargetSetter = enemyTargetSetter;
        _enemyTargetSetter.NewEnemyTargetHasBeenSet += OnNewTargetHasBeenSpawned;
    }

    public void OnNewTargetHasBeenSpawned(IDamageable target)
    {
        _target = target;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        _enemyTargetSetter.NewEnemyTargetHasBeenSet -= OnNewTargetHasBeenSpawned;
    }
}
