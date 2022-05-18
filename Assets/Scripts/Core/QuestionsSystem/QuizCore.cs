using System.Collections.Generic;

public class QuizCore
{   
    private QuestionGenerator _questionGenerator;
    private IAnswerHandler _answerHandler;

    private QuizItemHolder _quizItemHolder;

    public IAnswerHandler AnswerHandler => _answerHandler;

    private readonly List<string> _categoriesFileName = new List<string>()
    {
        "AlexGamerQuestions",
        "DotaQuestions",
        "SimpleQuestions",
        "SongQuestion",
        "MedicineQuestions"
    };

    public QuizCore(IAnswerHandler answerHandler, QuizItemHolder quizItemHolder)
    {
        //_questionGenerator = new QuestionGenerator(_categoriesFileName[Random.Range(0, _categoriesFileName.Count)]);
        _quizItemHolder = quizItemHolder;

        _questionGenerator = new QuestionGenerator(_categoriesFileName[0]);

        _answerHandler = answerHandler;
    }

    public void SetNextQuestion()
    {
        QuestionItem questionItem = _questionGenerator.Generate(_quizItemHolder);
        _answerHandler.SetCurrentQuestion(questionItem);
    }
}
