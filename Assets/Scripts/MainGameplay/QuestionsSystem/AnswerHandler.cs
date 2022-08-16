using System;
using UnityEngine;

public class AnswerHandler: IAnswerHandler
{
    private QuestionItem _currentQusetion;

    public event Action GaveCorrectAnswer;
    public event Action GaveIncorrectAnswer;

    private CristallSwipeHandler _cristallSwipeHandler;

    public AnswerHandler(CristallSwipeHandler cristallSwipeHandler)
    {
        _cristallSwipeHandler = cristallSwipeHandler;
    }

    public void SetCurrentQuestion(QuestionItem question)
    {
        _currentQusetion = question;
        _cristallSwipeHandler.CristallSwipeEnded += ApplyAnswerDirection;
    }

    public void ApplyAnswerDirection(Vector3 direction)
    {
        AnswerLocationSide answerLocation = SideDetector.GetLocation(direction);

        if (_currentQusetion != null) 
        {
            Answer answer = _currentQusetion.GetAnswer(answerLocation);

            if (answer.IsCorrect)
                GaveCorrectAnswer?.Invoke();
            else
                GaveIncorrectAnswer?.Invoke();

            _cristallSwipeHandler.CristallSwipeEnded -= ApplyAnswerDirection;
        }
        else
        {
            Debug.LogError("Questions is over");
        }
    }

    ~AnswerHandler()
    {
        _cristallSwipeHandler.CristallSwipeEnded -= ApplyAnswerDirection;
    }
}
