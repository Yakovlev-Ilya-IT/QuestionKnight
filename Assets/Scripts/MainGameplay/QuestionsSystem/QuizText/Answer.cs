using UnityEngine;

[RequireComponent(typeof(AnswerView))]
public class Answer: QuizText
{
    private bool _isCorrect;
    [SerializeField] private AnswerLocationSide _side;
    private AnswerView _view;

    public bool IsCorrect => _isCorrect;
    public AnswerLocationSide Side => _side;

    public void Initialize()
    {
        _view = GetComponent<AnswerView>();
        _view.Init();
    }

    public void UpdateInformation(string text, bool isCorrect)
    {
        UpdateInformation(text);
        _isCorrect = isCorrect;
        _view.SetText(_text);
    }
}
