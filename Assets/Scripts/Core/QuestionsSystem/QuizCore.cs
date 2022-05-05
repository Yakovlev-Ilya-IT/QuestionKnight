using System.Collections.Generic;
using UnityEngine;

public class QuizCore : MonoBehaviour
{   
    private QuestionGenerator _questionGenerator;
    private AnswerHandler _answerHandler;
    [SerializeField] private Question _question;
    [SerializeField] private List<Answer> _answers;

    private readonly List<string> _categoriesFileName = new List<string>()
    {
        "DotaQuestions",
        "SimpleQuestions",
        "SongQuestion",
        "MedicineQuestions"
    };

    public void Init(AnswerHandler answerHandler)
    {
        _questionGenerator = new QuestionGenerator(_categoriesFileName[Random.Range(0, _categoriesFileName.Count)]);
        _answerHandler = answerHandler;
    }

    public void SetNextQuestion()
    {
        QuestionItem questionItem = _questionGenerator.Generate(_question, _answers);
        _answerHandler.SetCurrentQuestion(questionItem);
    }
}
