using UnityEngine;

[RequireComponent(typeof(QuestionView))]
public class Question: QuizText
{
    private QuestionView _view;

    public void Initialize()
    {
        _view = GetComponent<QuestionView>();
        _view.Init();
    }

    public override void UpdateInformation(string text)
    {
        base.UpdateInformation(text);
        _view.SetText(_text);
    }
}
