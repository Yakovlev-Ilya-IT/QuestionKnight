using UnityEngine;

[RequireComponent(typeof(QuestionView))]
public class Question: MonoBehaviour
{
    private string _text;
    private QuestionView _view;

    private void Awake()
    {
        _view = GetComponent<QuestionView>();
    }

    public void Initialize(string text)
    {
        //проверить параметры
        _text = text;
        _view.SetText(_text);
    }
}
