using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForAnswerState : BaseGameState
{
    private QuizCore _quizCore;
    private AnswerHandler _answerHandler;

    public WaitingForAnswerState(Player player, GameScenario scenario, IStationStateSwitcher stateSwitcher, QuizCore quizCore, AnswerHandler answerHandler) : base(player, scenario, stateSwitcher)
    {
        _quizCore = quizCore;
        _answerHandler = answerHandler;
    }

    public override void Launch()
    {
        QuestionItem questionItem = _quizCore.SetNextQuestion();
        _answerHandler.SetCurrentQuestion(questionItem);
    }

    public override void PlayerAttack()
    {
        _stateSwitcher.SwitchState<PlayerAttackState>();
    }

    public override void EnemyAttack()
    {
        _stateSwitcher.SwitchState<EnemyAttackState>();
    }

    public override void SetNextQuestion()
    {
        //
    }

    public override void Stop()
    {
       //придумать скрытие ответов допустим
    }
}
