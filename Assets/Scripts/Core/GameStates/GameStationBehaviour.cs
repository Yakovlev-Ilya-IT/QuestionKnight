using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStationBehaviour : MonoBehaviour, IStationStateSwitcher
{
    [SerializeField] private QuizCore _quizCore;
    [SerializeField] private Cristall _cristall;
    [SerializeField] private GameScenario _scenario;
    [SerializeField] private TimeToAnswerHandler _timeToAnswerHandler;

    [SerializeField] private Transform _enemySpawnPoint;

    [SerializeField] private Player _playerPrefab;
    [SerializeField] private PlayerStatsConfig _playerStatsConfig;
    [SerializeField] private Transform _playerSpawnPoint;

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
        _timeToAnswerHandler.TimeToAnswerIsOver += OnGaveIncorrectAnswer;
    }

    private void Start()
    {
        _cristall.Init();
        _quizCore.Init(_answerHandler);

        Player player = Instantiate(_playerPrefab, _playerSpawnPoint);
        player.Initialize(_playerStatsConfig.MaxHealth, _playerStatsConfig.AttackDamage);

        _scenario.Init(_enemySpawnPoint, player);

        _states = new List<BaseGameState>()
        {
            new WaitingForAnswerState(player, _scenario, this, _quizCore, _timeToAnswerHandler),
            new EnemyAttackState(player, _scenario, this),
            new PlayerAttackState(player, _scenario, this)
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

    private void OnDisable()
    {
        _answerHandler.GaveCorrectAnswer -= OnGaveCorrectAnswer;
        _answerHandler.GaveIncorrectAnswer -= OnGaveIncorrectAnswer;
        _timeToAnswerHandler.TimeToAnswerIsOver -= OnGaveIncorrectAnswer;
    }

    public void SwitchState<T>() where T : BaseGameState
    {
        BaseGameState state = _states.FirstOrDefault(s => s is T);

        _currentState.Stop();
        state.Launch();
        _currentState = state;
    }
}
