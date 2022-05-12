using System.Collections.Generic;
using System.Linq;

public class GameStationBehaviour : IStationStateSwitcher
{
    private QuizCore _quizCore;
    private GameScenario _scenario;
    private TimeToAnswerHandler _timeToAnswerHandler;

    private List<BaseGameState> _states;
    private BaseGameState _currentState;

    public GameStationBehaviour(QuizCore quizCore, GameScenario scenario, TimeToAnswerHandler timeToAnswerHandler, Player player)
    {
        _quizCore = quizCore;
        _scenario = scenario;
        _timeToAnswerHandler = timeToAnswerHandler;

        _quizCore.AnswerHandler.GaveCorrectAnswer += OnGaveCorrectAnswer;
        _quizCore.AnswerHandler.GaveIncorrectAnswer += OnGaveIncorrectAnswer;
        _timeToAnswerHandler.TimeToAnswerIsOver += OnGaveIncorrectAnswer;

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

    ~GameStationBehaviour()
    {
        _quizCore.AnswerHandler.GaveCorrectAnswer -= OnGaveCorrectAnswer;
        _quizCore.AnswerHandler.GaveIncorrectAnswer -= OnGaveIncorrectAnswer;
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
