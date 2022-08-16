using Zenject;

public class ConfigsHolder
{
    LevelConfig _levelConfig;
    AdventureConfig _adventureConfig;
    QuestionsCategorie _questionsCategorie;

    public LevelConfig LevelConfig => _levelConfig;
    public AdventureConfig AdventureConfig => _adventureConfig;
    public QuestionsCategorie QuestionsCategorie => _questionsCategorie;

    public ConfigsHolder() { }
    
    [Inject]
    public ConfigsHolder(AdventureConfig adventureConfig, LevelConfig levelConfig, QuestionsCategorie questionsCategorie)
    {
        _adventureConfig = adventureConfig;
        _levelConfig = levelConfig;
        _questionsCategorie = questionsCategorie;
    }

    public void AdventureSelect(AdventureConfig adventureConfig)
    {
        _adventureConfig = adventureConfig;
    }

    public void LevelSelect(LevelConfig levelConfig)
    {
        _levelConfig = levelConfig;
    }

    public void QuestionsCategorieSelect(QuestionsCategorie questionsCategorie)
    {
        _questionsCategorie = questionsCategorie;
    }
}
