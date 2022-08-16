using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelsGridBuilder : MonoBehaviour
{
    [SerializeField] private LevelSelectionButton _levelButtonPrefab;
    [SerializeField] private GridLayoutGroup _grid;

    private const int FirstButtonLevelIndex = 0;

    private LevelsDataProvider _levelsDataProvider;
    private ISaver _saver;
    private ILevelSelectionMediator _mediator;

    [Inject]
    private void Construct(LevelsDataProvider levelsDataProvider, ISaver saver, ILevelSelectionMediator mediator)
    {
        _levelsDataProvider = levelsDataProvider;
        _saver = saver;
        _mediator = mediator;
    }

    public LevelSelectionButton[] Build(AdventureConfig adventureConfig)
    {
        LevelConfig[] levels = _levelsDataProvider.LoadAll(adventureConfig.AdventureNumber);

        adventureConfig.LevelsCount = levels.Length;
        _saver.Save(adventureConfig);

        return BuildLevelsGrid(levels, adventureConfig.CompleteLevels);
    }

    public void Clear(LevelSelectionButton[] buttons)
    {
        foreach (var button in buttons)
        {
            Destroy(button.gameObject);
        }
    }

    private LevelSelectionButton[] BuildLevelsGrid(LevelConfig[] levels, int completeLevels)
    {
        LevelSelectionButton[] levelSelectionButtons = new LevelSelectionButton[levels.Length];
        List<ISelectable> selectables = new List<ISelectable>();

        for (int i = 0; i < levels.Length; i++)
        {
            LevelSelectionButton levelButton = Instantiate(_levelButtonPrefab, _grid.transform);
            InitializeButton(levelButton, levels[i], i + 1, completeLevels);

            levelSelectionButtons[i] = levelButton;
            selectables.Add(levelButton);
        }

        SelectionHandler buttonSelectionHandler = new SelectionHandler(selectables);

        return levelSelectionButtons;
    }

    private void InitializeButton(LevelSelectionButton button, LevelConfig levelConfig, int levelNumber, int completeLevels)
    {
        button.Initialize(levelConfig, (levelNumber).ToString());

        if (levelNumber > completeLevels + 1)
        {
            button.Lock();
            return;
        }
        else
        {
            button.Unlock();
            if(levelNumber - 1 == FirstButtonLevelIndex)
            {
                _mediator.SendLevelConfig(levelConfig);
                button.Select();
            }
        }
    }
}
