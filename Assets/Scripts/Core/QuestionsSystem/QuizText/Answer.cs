using UnityEngine;

public class Answer: QuizText
{
    private bool _isCorrect;
    [SerializeField] private AnswerLocationSide _side;

    public bool IsCorrect => _isCorrect;
    public AnswerLocationSide Side => _side;

    public new void Init()
    {
        base.Init();
    }

    public void UpdateInformation(string text, bool isCorrect)
    {
        //������� ���������
        UpdateInformation(text);
        _isCorrect = isCorrect;
    }
}
