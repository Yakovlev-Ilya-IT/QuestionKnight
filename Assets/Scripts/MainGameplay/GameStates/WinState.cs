using UnityEngine;

public class WinState : BaseLevelCycleState
{
    private LevelSaver _levelSaver;
    private IGameplayMediator _mediator;

    public WinState(Player player, LevelScenario scenario, IStationStateSwitcher stateSwitcher, LevelSaver levelSaver, IGameplayMediator mediator) : base(player, scenario, stateSwitcher)
    {
        _levelSaver = levelSaver;
        _mediator = mediator;
    }

    public override void Launch()
    {
        Debug.Log("WIN");
        _levelSaver.Save(LevelStatus.LevelPassed);
        _mediator.ShowLevelWinPanel();
    }

    public override void PlayerAttack() { }

    public override void EnemyAttack() { }

    public override void Stop() { }
}
