using System;

public interface IAnswerHandler
{
    public event Action GaveCorrectAnswer;
    public event Action GaveIncorrectAnswer;
    public void SetCurrentQuestion(QuestionItem question);
}