using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WinPanel : LevelResultWindow
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private WinPanelView _view;

    [Inject]
    private void Construct(IGameplayMediator mediator)
    {
        Initialize(mediator);
        _view.Initialize();
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
        _mediator.GoToNextLevel();
    }

    private bool CheckEndAdventure()
    {
        return !_mediator.TryLoadNextLevel(out LevelConfig levelConfig);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
    }
}
