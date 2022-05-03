using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStationBehaviour : MonoBehaviour, IStationStateSwitcher
{
    [SerializeField] private QuizCore _quizCore;
    [SerializeField] private Cristall _cristall;
    [SerializeField] private GameScenario _scenario;

    [SerializeField] private Transform _enemySpawnPoint;

    [SerializeField] private Player _player;

    private AnswerHandler _answerHandler;

    private List<BaseGameState> _states;
    private BaseGameState _currentState;

    private void Awake()
    {
        _answerHandler = new AnswerHandler();
    }

    private void OnEnable()
    {
        _answerHandler.GaveCorrectAnswer += OnGaveCorrectAnswer;
        _answerHandler.GaveIncorrectAnswer += OnGaveIncorrectAnswer;
    }

    private void Start()
    {
        _cristall.Init();
        _quizCore.Init();
        _player.Initialize(_scenario);
        _scenario.Init(_enemySpawnPoint, _player);

        QuestionItem questionItem = _quizCore.SetNextQuestion();
        _answerHandler.SetCurrentQuestion(questionItem);
        _scenario.Progress();

        _states = new List<BaseGameState>()
        {
            new WaitingForAnswerState(_player, _scenario, this, _quizCore, _answerHandler),
            new EnemyAttackState(_player, _scenario, this),
            new PlayerAttackState(_player, _scenario, this)
        };

        _currentState = _states[0];
    }

    private void OnGaveCorrectAnswer()
    {
        Debug.Log("Вы ответили правильно");
        _currentState.PlayerAttack();
    }

    private void OnGaveIncorrectAnswer()
    {
        Debug.Log("Вы ответили неправильно");
        _currentState.EnemyAttack();
    }

    private void OnDisable()
    {
        _answerHandler.GaveCorrectAnswer -= OnGaveCorrectAnswer;
        _answerHandler.GaveIncorrectAnswer -= OnGaveIncorrectAnswer;
    }

    public void SwitchState<T>() where T : BaseGameState
    {
        BaseGameState state = _states.FirstOrDefault(s => s is T);

        _currentState.Stop();
        _currentState = state;
        _currentState.Launch();
    }
}
