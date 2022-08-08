using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WinPanel : LevelResultWindow
{
    [SerializeField] private Button _nextLevelButton;
    private NextLevelHandler _nextLevelHandler;
    [SerializeField] private WinPanelView _view;

    [Inject]
    protected void Initialize(ISceneLoadMediator mediator, NextLevelHandler nextLevelHandler)
    {
        Initialize(mediator);
        _view.Initialize();
        _nextLevelHandler = nextLevelHandler;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
    }

    public override void Open()
    {
        base.Open();

        if (CheckEndAdventure())
        {
            _nextLevelButton.gameObject.SetActive(false);
            _view.SetAdventureCompleteTitle();
        }
        else
        {
            _nextLevelButton.gameObject.SetActive(true);
            _view.SetLevelCompleteTitle();
        }

        _view.Open();
    }

    private void OnNextLevelButtonClick()
    {
        _mediator.GoToLevel(_nextLevelHandler.AdventureConfig, _nextLevelHandler.NextLevelConfig, _nextLevelHandler.QuestionsCategorie);
    }

    private bool CheckEndAdventure()
    {
        return !_nextLevelHandler.TryLoadNextLevel();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
    }
}
