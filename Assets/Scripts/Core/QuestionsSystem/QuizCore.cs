using System.Collections.Generic;
using UnityEngine;

public class QuizCore : MonoBehaviour
{   
    [SerializeField] private QuestionGenerator _questionGenerator;
    [SerializeField] private Question _question;
    [SerializeField] private List<Answer> _answers;

    private readonly List<string> _categoriesFileName = new List<string>()
    {
        "DotaQuestions",
        "SimpleQuestions",
        "SongQuestion",
        "MedicineQuestions"
    };

    public void Init()
    {
        _questionGenerator = new QuestionGenerator(_categoriesFileName[Random.Range(0, _categoriesFileName.Count)]);
    }

    public QuestionItem SetNextQuestion()
    {
        QuestionItem questionItem = _questionGenerator.Generate(_question, _answers);

        return questionItem;
    }
}
