using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForAnswerState : BaseLevelCycleState
{
    private QuizCore _quizCore;
    private TimeToAnswerHandler _timeToAnswerHandler;

    public WaitingForAnswerState(Player player, LevelScenario scenario, IStationStateSwitcher stateSwitcher, QuizCore quizCore, TimeToAnswerHandler timeToAnswerHandler) : base(player, scenario, stateSwitcher)
    {
        _quizCore = quizCore;
        _timeToAnswerHandler = timeToAnswerHandler;
    }

    public override void Launch()
    {
        if (_scenario.TryIncreaseProgress())
        {
            _quizCore.SetNextQuestion();
            _timeToAnswerHandler.Set(_scenario.CurrentEnemy.TimeToAnswer);
            _timeToAnswerHandler.StartCountingAnswerTime();
        }
        else
        {
            _stateSwitcher.SwitchState<WinState>();
        }
    }

    public override void PlayerAttack()
    {
        _stateSwitcher.SwitchState<PlayerAttackState>();
    }

    public override void EnemyAttack()
    {
        _stateSwitcher.SwitchState<EnemyAttackState>();
    }

    public override void Stop()
    {
        _timeToAnswerHandler.StopCountingAnswerTime();
    }
}
