using System.Collections.Generic;
using UnityEngine;

public class LevelInstaller : MonoBehaviour
{
    private QuizCore _quizCore;
    [SerializeField] private Cristall _cristall;
    [SerializeField] private GameScenario _scenario;
    [SerializeField] private TimeToAnswerHandler _timeToAnswerHandler;

    [SerializeField] private Transform _enemySpawnPoint;

    [SerializeField] private Player _playerPrefab;
    [SerializeField] private PlayerStatsConfig _playerStatsConfig;
    [SerializeField] private Transform _playerSpawnPoint;

    [SerializeField] private Question _question;
    [SerializeField] private List<Answer> _answers;

    private AnswerHandler _answerHandler;

    private void Awake()
    {
        _answerHandler = new AnswerHandler();
    }

    private void Start()
    {
        _cristall.Init();
        _quizCore = new QuizCore(_answerHandler, _question, _answers);

        Player player = Instantiate(_playerPrefab, _playerSpawnPoint);
        player.Initialize(_playerStatsConfig.MaxHealth, _playerStatsConfig.AttackDamage);

        _scenario.Init(_enemySpawnPoint, player);

        GameStationBehaviour gameStationBehaviour = new GameStationBehaviour(_quizCore, _scenario, _timeToAnswerHandler, player);
    }
}
