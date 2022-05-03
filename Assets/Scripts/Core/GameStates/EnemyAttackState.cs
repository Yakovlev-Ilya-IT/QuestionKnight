using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseGameState
{
    public EnemyAttackState(Player player, GameScenario scenario, IStationStateSwitcher stateSwitcher) : base(player, scenario, stateSwitcher)
    {
    }

    public override void Launch()
    {
        _player.ApplyDamageFinished += OnApplyDamageFinished;
        _scenario.CurrentEnemy.DealDamage();
    }

    private void OnApplyDamageFinished()
    {
        if(_player.CurrentHealth <= 0)
        {
            Debug.Log("LOOSE");
        }
        else
        {
            _stateSwitcher.SwitchState<WaitingForAnswerState>();
        }
    }
    public override void Stop()
    {
        _player.ApplyDamageFinished -= OnApplyDamageFinished;
    }

    public override void EnemyAttack() {}

    public override void PlayerAttack() {}

    public override void SetNextQuestion() {}
}
