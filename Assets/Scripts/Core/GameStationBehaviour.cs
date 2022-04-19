using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStationBehaviour : MonoBehaviour
{
    [SerializeField] private QuizCore _quizCore;
    [SerializeField] private Cristall _cristall;

    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private Transform _enemySpawnPoint;
    private Enemy _enemy;
    [SerializeField] private Player _player;

    private AnswerHandler _answerHandler;

    private void Awake()
    {
        _answerHandler = new AnswerHandler();
        _answerHandler.GaveCorrectAnswer += OnGaveCorrectAnswer;
        _answerHandler.GaveIncorrectAnswer += OnGaveIncorrectAnswer;
    }

    private void Start()
    {
        _cristall.Init();
        _quizCore.Init();

        QuestionItem questionItem = _quizCore.SetNextQuestion();

        _enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(EnemyType)).Length), _player);
        _enemy.SpawnTo(_enemySpawnPoint.position);

        _answerHandler.SetCurrentQuestion(questionItem);
    }

    private void OnGaveCorrectAnswer()
    {
        Debug.Log("Вы ответили правильно");
        QuestionItem questionItem = _quizCore.SetNextQuestion();
        _answerHandler.SetCurrentQuestion(questionItem);
    }

    private void OnGaveIncorrectAnswer()
    {
        Debug.Log("Вы ответили неправильно");

        _enemy.DealDamage();////////////////////////////

        QuestionItem questionItem = _quizCore.SetNextQuestion();
        _answerHandler.SetCurrentQuestion(questionItem);
    }

    private void OnDisable()
    {
        _answerHandler.GaveCorrectAnswer -= OnGaveCorrectAnswer;
        _answerHandler.GaveIncorrectAnswer -= OnGaveIncorrectAnswer;
    }
}
