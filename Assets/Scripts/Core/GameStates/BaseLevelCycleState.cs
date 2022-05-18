using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLevelCycleState
{
    protected readonly Player _player;
    protected readonly IStationStateSwitcher _stateSwitcher;
    protected readonly GameScenario _scenario;


    protected BaseLevelCycleState (Player player, GameScenario scenario, IStationStateSwitcher stateSwitcher)
    {
        _player = player;
        _stateSwitcher = stateSwitcher;
        _scenario = scenario;
    }

    public abstract void Launch();

    public abstract void Stop();

    public abstract void SetNextQuestion();

    public abstract void PlayerAttack();

    public abstract void EnemyAttack();
}
