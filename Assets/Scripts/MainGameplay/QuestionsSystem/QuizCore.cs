using System.Collections.Generic;

public class QuizCore
{   
    private QuestionGenerator _questionGenerator;
    private IAnswerHandler _answerHandler;

    private QuizItemHolder _quizItemHolder;

    public IAnswerHandler AnswerHandler => _answerHandler;

    private readonly Dictionary<QuestionsCategorie, string> _questionCategorieToCategorieFileName = new Dictionary<QuestionsCategorie, string>()
    {
        {QuestionsCategorie.Literature, "AlexGamerQuestions"},
        {QuestionsCategorie.Music, "SongQuestion"},
        {QuestionsCategorie.Mathematics, "DotaQuestions"},
        {QuestionsCategorie.RussianLanguage, "SimpleQuestions"},
        {QuestionsCategorie.Medicine, "MedicineQuestions"}
    };

    public QuizCore(IAnswerHandler answerHandler, QuizItemHolder quizItemHolder, QuestionsCategorie questionsCategorie)
    {
        _quizItemHolder = quizItemHolder;

        _questionGenerator = new QuestionGenerator(_questionCategorieToCategorieFileName[questionsCategorie]);

        _answerHandler = answerHandler;
    }

    public void SetNextQuestion()
    {
        QuestionItem questionItem = _questionGenerator.Generate(_quizItemHolder);
        _answerHandler.SetCurrentQuestion(questionItem);
    }
}
