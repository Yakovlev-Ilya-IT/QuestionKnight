public abstract class BaseLevelCycleState
{
    protected readonly Player _player;
    protected readonly IStationStateSwitcher _stateSwitcher;
    protected readonly LevelScenario _scenario;


    protected BaseLevelCycleState (Player player, LevelScenario scenario, IStationStateSwitcher stateSwitcher)
    {
        _player = player;
        _stateSwitcher = stateSwitcher;
        _scenario = scenario;
    }

    public abstract void Launch();

    public abstract void Stop();

    public abstract void PlayerAttack();

    public abstract void EnemyAttack();
}
