using System.Collections.Generic;

public class QuizCore
{   
    private QuestionGenerator _questionGenerator;
    private AnswerHandler _answerHandler;

    private Question _question;
    private List<Answer> _answers;

    public AnswerHandler AnswerHandler => _answerHandler;

    private readonly List<string> _categoriesFileName = new List<string>()
    {
        "AlexGamerQuestions",
        "DotaQuestions",
        "SimpleQuestions",
        "SongQuestion",
        "MedicineQuestions"
    };

    public QuizCore(AnswerHandler answerHandler, Question question, List<Answer> answers)
    {
        //_questionGenerator = new QuestionGenerator(_categoriesFileName[Random.Range(0, _categoriesFileName.Count)]);
        _question = question;
        _answers = answers;

        _questionGenerator = new QuestionGenerator(_categoriesFileName[0]);

        _answerHandler = answerHandler;
    }

    public void SetNextQuestion()
    {
        QuestionItem questionItem = _questionGenerator.Generate(_question, _answers);
        _answerHandler.SetCurrentQuestion(questionItem);
    }
}
