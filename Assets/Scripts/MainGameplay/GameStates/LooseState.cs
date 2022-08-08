using UnityEngine;

public class LooseState : BaseLevelCycleState
{
    private IGameplayMediator _mediator;

    public LooseState(Player player, LevelScenario scenario, IStationStateSwitcher stateSwitcher, IGameplayMediator mediator) : base(player, scenario, stateSwitcher)
    {
        _mediator = mediator;
    }

    public override void Launch()
    {
        Debug.Log("Loose");
        _mediator.ShowLevelLoosePanel();
    }

    public override void PlayerAttack() { }

    public override void EnemyAttack() { }

    public override void Stop() { }
}
