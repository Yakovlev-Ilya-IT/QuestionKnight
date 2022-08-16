using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoosePanel : LevelResultWindow
{
    [SerializeField] private Button _restartLevelButton;
    [SerializeField] LoosePanelView _view;

    [Inject]
    private void Construct(IGameplayMediator mediator)
    {
        Initialize(mediator);
        _view.Initialize();
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
        _mediator.RestartLevel();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _restartLevelButton.onClick.AddListener(OnRestartLevelButtonClick);
    }
}
