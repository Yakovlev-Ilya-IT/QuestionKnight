using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class QuizItemHolder : MonoBehaviour
{
    [SerializeField] private Question _question;
    [SerializeField] private List<Answer> _answers;

    public Question Question => _question;
    public List<Answer> Answers => _answers;

    [Inject]
    private void Construct()
    {
        _question.Initialize();

        foreach (Answer answer in _answers)
        {
            answer.Initialize();
        }
    }
}
