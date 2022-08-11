using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoosePanel : LevelResultWindow
{
    [SerializeField] private Button _restartLevelButton;
    private NextLevelHandler _nextLevelHandler;
    [SerializeField] LoosePanelView _view;

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
        _restartLevelButton.onClick.AddListener(OnRestartLevelButtonClick);
    }

    public override void Open()
    {
        base.Open();
        _view.Open();
    }

    private void OnRestartLevelButtonClick()
    {
        _mediator.GoToLevel(_nextLevelHandler.AdventureConfig, _nextLevelHandler.CurrentLevelConfig, _nextLevelHandler.QuestionsCategorie);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _restartLevelButton.onClick.AddListener(OnRestartLevelButtonClick);
    }
}
