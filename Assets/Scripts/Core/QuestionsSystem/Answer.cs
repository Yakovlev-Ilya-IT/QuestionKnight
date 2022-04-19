using UnityEngine;

[RequireComponent(typeof(AnswerView))]
public class Answer: MonoBehaviour
{
    private string _text;
    private bool _isCorrect;
    private AnswerView _view;
    [SerializeField] private AnswerLocationSide _side;

    public bool IsCorrect => _isCorrect;
    public AnswerLocationSide Side => _side;

    private void Awake()
    {
        _view = GetComponent<AnswerView>();
    }

    public void Initialize(string text, bool isCorrect)
    {
        //проверить параметры
        _text = text;
        _isCorrect = isCorrect;
        _view.SetText(_text);
    }
}
