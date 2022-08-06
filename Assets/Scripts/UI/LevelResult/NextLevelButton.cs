using Zenject;

public class NextLevelButton : SimpleButton
{
    private ISceneLoadMediator _sceneLoadMediator;
    private LevelConfig _nextLevelConfig;
    private AdventureConfig _adventureConfig;
    private QuestionsCategorie _questionsCategorie;

    [Inject]
    public void Initialize(ISceneLoadMediator sceneLoadMediator)
    {
        _sceneLoadMediator = sceneLoadMediator;
    }

    public void SetNextLevelConfig(AdventureConfig adventureConfig, LevelConfig nextLevelConfig, QuestionsCategorie questionsCategorie)
    {
        _adventureConfig = adventureConfig;
        _nextLevelConfig = nextLevelConfig;
        _questionsCategorie = questionsCategorie;
    }

    protected override void Click()
    {
        _sceneLoadMediator.GoToLevel(_adventureConfig, _nextLevelConfig, _questionsCategorie);
    }
}
