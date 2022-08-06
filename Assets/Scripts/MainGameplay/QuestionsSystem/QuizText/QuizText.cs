using UnityEngine;

[RequireComponent(typeof(QuizTextView))]
public abstract class QuizText : MonoBehaviour
{
    protected string _text;
    private QuizTextView _view;

    public void Init()
    {
        _view = GetComponent<QuizTextView>();
        _view.Init();
    }

    public void UpdateInformation(string text)
    {
        _text = text;
        _view.SetText(_text);
    }
}
