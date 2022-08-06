using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelCycleBehaviour : IStationStateSwitcher, IDisposable
{
    private QuizCore _quizCore;
    private TimeToAnswerHandler _timeToAnswerHandler;

    private List<BaseLevelCycleState> _states;
    private BaseLevelCycleState _currentState;

    public LevelCycleBehaviour(QuizCore quizCore, LevelScenario scenario, TimeToAnswerHandler timeToAnswerHandler, Player player, LevelSaver levelSaver, IGameplayMediator mediator)
    {
        _quizCore = quizCore;
        _timeToAnswerHandler = timeToAnswerHandler;

        _quizCore.AnswerHandler.GaveCorrectAnswer += OnGaveCorrectAnswer;
        _quizCore.AnswerHandler.GaveIncorrectAnswer += OnGaveIncorrectAnswer;
        _timeToAnswerHandler.TimeToAnswerIsOver += OnGaveIncorrectAnswer;

        _states = new List<BaseLevelCycleState>()
        {
            new WaitingForAnswerState(player, scenario, this, _quizCore, _timeToAnswerHandler),
            new EnemyAttackState(player, scenario, this),
            new PlayerAttackState(player, scenario, this),
            new WinState(player, scenario, this, levelSaver, mediator)
        };

        _states[0].Launch();
        _currentState = _states[0];
    }

    private void OnGaveCorrectAnswer()
    {
        _currentState.PlayerAttack();
    }

    private void OnGaveIncorrectAnswer()
    {
        _currentState.EnemyAttack();
    }

    public void SwitchState<T>() where T : BaseLevelCycleState
    {
        BaseLevelCycleState state = _states.FirstOrDefault(s => s is T);

        _currentState.Stop();
        state.Launch();
        _currentState = state;
    }

    public void Dispose()
    {
        _quizCore.AnswerHandler.GaveCorrectAnswer -= OnGaveCorrectAnswer;
        _quizCore.AnswerHandler.GaveIncorrectAnswer -= OnGaveIncorrectAnswer;
        _timeToAnswerHandler.TimeToAnswerIsOver -= OnGaveIncorrectAnswer;
    }
}
