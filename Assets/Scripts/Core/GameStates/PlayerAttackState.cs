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
        _scenario.CurrentEnemy.ProtectionStageIsOver += ProtectionStageIsOver;
        _scenario.CurrentEnemy.Died += ProtectionStageIsOver;
        _player.DealDamage();
    }

    private void ProtectionStageIsOver()
    {
        _stateSwitcher.SwitchState<WaitingForAnswerState>();
    }

    public override void Stop()
    {
        if (_scenario.CurrentEnemy != null)
        {
            _scenario.CurrentEnemy.ProtectionStageIsOver -= ProtectionStageIsOver;
            _scenario.CurrentEnemy.Died -= ProtectionStageIsOver;
        }
    }
    public override void EnemyAttack() { }


    public override void PlayerAttack() { }

    public override void SetNextQuestion() { }
}
