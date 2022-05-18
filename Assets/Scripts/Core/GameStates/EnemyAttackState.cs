using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseLevelCycleState
{
    public EnemyAttackState(Player player, GameScenario scenario, IStationStateSwitcher stateSwitcher) : base(player, scenario, stateSwitcher)
    {
    }

    public override void Launch()
    {
        _player.ProtectionStageIsOver += OnProtectionStageIsOver;
        _player.Died += OnDied;
        _scenario.CurrentEnemy.DealDamage();
    }

    private void OnProtectionStageIsOver()
    {
        _stateSwitcher.SwitchState<WaitingForAnswerState>();
    }

    private void OnDied()
    {
        Debug.Log("LOOSE");
    }

    public override void Stop()
    {
        _player.ProtectionStageIsOver -= OnProtectionStageIsOver;
        _player.Died -= OnDied;
    }

    public override void EnemyAttack() {}

    public override void PlayerAttack() {}

    public override void SetNextQuestion() {}
}
