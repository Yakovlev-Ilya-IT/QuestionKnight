using Zenject;
using UnityEngine;
public class NextLevelHandler
{
    private LevelsDataProvider _levelsDataProvider;

    private LevelConfig _nextLevelConfig;
    private LevelConfig _currentLevelConfig;
    private AdventureConfig _adventureConfig;
    private QuestionsCategorie _questionsCategorie;

    public LevelConfig NextLevelConfig
    {
        get
        {
            if( _nextLevelConfig != null )
                return _nextLevelConfig;
            else
            {
                Debug.LogError("NextLevel is empty");
                return null;
            }
        }
    }
    public LevelConfig CurrentLevelConfig => _currentLevelConfig;
    public AdventureConfig AdventureConfig => _adventureConfig;
    public QuestionsCategorie QuestionsCategorie => _questionsCategorie;

    [Inject]
    private void Initialize(LevelsDataProvider levelsDataProvider, AdventureConfig adventureConfig, LevelConfig currentLevelConfig, QuestionsCategorie questionsCategorie)
    {
        _levelsDataProvider = levelsDataProvider;
        _currentLevelConfig = currentLevelConfig;
        _adventureConfig = adventureConfig;
        _questionsCategorie = questionsCategorie;
    }

    public bool TryLoadNextLevel()
    {
        if(_levelsDataProvider.TryLoadLevel(_adventureConfig.AdventureNumber, _currentLevelConfig.LevelNumber + 1, out LevelConfig nextLevelConfig))
        {
            _nextLevelConfig = nextLevelConfig;
            return true;
        }

        return false;
    }
}
