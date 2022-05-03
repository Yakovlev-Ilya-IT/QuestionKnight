using System;
using UnityEngine;

public class AnswerHandler
{
    private QuestionItem _currentQusetion;

    public event Action GaveCorrectAnswer;
    public event Action GaveIncorrectAnswer;

    public void SetCurrentQuestion(QuestionItem question)
    {
        _currentQusetion = question;
        QuizEventHandler.CristallSwipeEnded += ApplyAnswerDirection;
    }

    public void ApplyAnswerDirection(Vector3 direction)
    {
        AnswerLocationSide answerLocation = SideDetector.GetLocation(direction);

        if (_currentQusetion != null)//сделать проверку на налл текущего ответа (его может и не быть)
        {
            Answer answer = _currentQusetion.GetAnswer(answerLocation);

            if (answer.IsCorrect)
                GaveCorrectAnswer?.Invoke();
            else
                GaveIncorrectAnswer?.Invoke();

            QuizEventHandler.CristallSwipeEnded -= ApplyAnswerDirection;
        }
        else
        {
            Debug.LogError("Ответы закончились");
        }
    }

    ~AnswerHandler()
    {
        QuizEventHandler.CristallSwipeEnded -= ApplyAnswerDirection;
    }
}
