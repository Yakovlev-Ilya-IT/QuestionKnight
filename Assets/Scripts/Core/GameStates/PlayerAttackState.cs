using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : BaseGameState
{
    public PlayerAttackState(Player player, GameScenario scenario, IStationStateSwitcher stateSwitcher) : base(player, scenario, stateSwitcher)
    {
    }
    public override void Launch()
    {
        _scenario.CurrentEnemy.ApplyDamageFinished += OnApplyDamageFinished;
        _player.DealDamage();
    }

    private void OnApplyDamageFinished()
    {
        if (_scenario.Progress())
        {
            _stateSwitcher.SwitchState<WaitingForAnswerState>();
        }
        else
        {
            Debug.Log("WIN");
        }
    }

    public override void Stop()
    {
        _scenario.CurrentEnemy.ApplyDamageFinished -= OnApplyDamageFinished;
    }
    public override void EnemyAttack() { }


    public override void PlayerAttack() { }

    public override void SetNextQuestion() { }
}
