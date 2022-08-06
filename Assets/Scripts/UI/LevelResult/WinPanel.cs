using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WinPanel : PopupWindow
{
    [SerializeField] private NextLevelButton _nextLevelButton;
    
    private LevelsDataProvider _levelsDataProvider;
    private LevelConfig _levelConfig;
    private AdventureConfig _adventureConfig;
    private QuestionsCategorie _questionsCategorie;

    [Inject]
    private void Initialize(LevelsDataProvider levelsDataProvider, AdventureConfig adventureConfig, LevelConfig levelConfig, QuestionsCategorie questionsCategorie)
    {
        _levelsDataProvider = levelsDataProvider;
        _levelConfig = levelConfig;
        _adventureConfig = adventureConfig;
        _questionsCategorie = questionsCategorie;
    }

    public override void Open()
    {
        base.Open();

        if (_levelsDataProvider.TryLoadLevel(_adventureConfig.AdventureNumber, _levelConfig.LevelNumber + 1, out LevelConfig nextLevelConfig))
            _nextLevelButton.SetNextLevelConfig(_adventureConfig, nextLevelConfig, _questionsCategorie);
        else
            _nextLevelButton.gameObject.SetActive(false);

    }
}
