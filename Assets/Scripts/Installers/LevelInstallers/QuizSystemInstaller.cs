using UnityEngine;
using Zenject;

public class QuizSystemInstaller : MonoInstaller
{
    [SerializeField] private TimeToAnswerHandler _timeToAnswerHandler;
    [SerializeField] private QuizItemHolder _quizItemHolder;

    public override void InstallBindings()
    {
        BindQuestionSystem();
        BindTimerToAnswer();
    }

    private void BindQuestionSystem()
    {
        Container.Bind<QuizItemHolder>().FromInstance(_quizItemHolder).AsSingle();
        Container.Bind<IAnswerHandler>().To<AnswerHandler>().AsSingle();
        Container.Bind<QuizCore>().AsSingle();
    }
    private void BindTimerToAnswer()
    {
        Container.Bind<TimeToAnswerHandler>().FromInstance(_timeToAnswerHandler).AsSingle();
    }
}