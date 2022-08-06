using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelFiller : MonoBehaviour
{
    [SerializeField] private LevelSelectionButton _levelButtonPrefab;
    [SerializeField] private GridLayoutGroup _grid;

    private const int FirstButtonLevelIndex = 0;

    private List<LevelSelectionButton> _levelSelectionButtons;
    private LevelsDataProvider _levelsDataProvider;
    private ISaver _saver;
    private ILevelSelectionMediator _mediator;

    [Inject]
    private void Initialize(LevelsDataProvider levelsDataProvider, ISaver saver, ILevelSelectionMediator mediator)
    {
        _levelsDataProvider = levelsDataProvider;
        _saver = saver;
        _mediator = mediator;
    }

    public void Fill(AdventureConfig adventureConfig)
    {
        LevelConfig[] levels = _levelsDataProvider.LoadAll(adventureConfig.AdventureNumber);

        adventureConfig.LevelsCount = levels.Length;
        _saver.Save(adventureConfig);

        FillLevelsGrid(levels, adventureConfig.CompleteLevels);
    }

    public void Clear()
    {
        foreach (var button in _levelSelectionButtons)
        {
            Destroy(button.gameObject);
        }

        _levelSelectionButtons.Clear();
    }

    private void FillLevelsGrid(LevelConfig[] levels, int completeLevels)
    {
        _levelSelectionButtons = new List<LevelSelectionButton>();
        List<ISelectable> selectables = new List<ISelectable>();

        for (int i = 0; i < levels.Length; i++)
        {
            LevelSelectionButton levelButton = Instantiate(_levelButtonPrefab, _grid.transform);
            levelButton = InitializeButton(levelButton, levels[i], i + 1, completeLevels);

            _levelSelectionButtons.Add(levelButton);
            selectables.Add(levelButton);
        }

        SelectionHandler buttonSelectionHandler = new SelectionHandler(selectables);
    }

    private LevelSelectionButton InitializeButton(LevelSelectionButton levelButton, LevelConfig levelConfig, int levelNumber, int completeLevels)
    {
        levelButton.Initialize(levelConfig, (levelNumber).ToString(), _mediator);

        if (levelNumber > completeLevels + 1)
        {
            levelButton.Lock();
        }
        else
        {
            levelButton.Unlock();
            if(levelNumber - 1 == FirstButtonLevelIndex)
            {
                _mediator.SendLevelConfig(levelConfig);
                levelButton.Select();
            }
        }

        return levelButton;
    }
}
