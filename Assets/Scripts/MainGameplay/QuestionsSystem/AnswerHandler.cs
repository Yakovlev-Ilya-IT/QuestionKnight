using System;
using UnityEngine;

public class AnswerHandler: IAnswerHandler
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

        if (_currentQusetion != null)//������� �������� �� ���� �������� ������ (��� ����� � �� ����)
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
            Debug.LogError("Questions is over");
        }
    }

    ~AnswerHandler()
    {
        QuizEventHandler.CristallSwipeEnded -= ApplyAnswerDirection;
    }
}