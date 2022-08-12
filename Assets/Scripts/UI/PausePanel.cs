using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PausePanel : Window
{
    [SerializeField] private Button _levelSelectionButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _closeButton;

    [SerializeField] private PausePanelView _view;

    private IGameplayMediator _mediator;

    [Inject]
    protected void Initialize(IGameplayMediator mediator)
    {
        _mediator = mediator;
    }

    private void OnEnable()
    {
        _levelSelectionButton.onClick.AddListener(OnLevelSelectionButtonClick);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _closeButton.onClick.AddListener(OnCloseButtonClick);
    }

    private void OnCloseButtonClick()
    {
        _mediator.HidePausePanel();
    }

    private void OnRestartButtonClick()
    {
        _mediator.RestartLevel();
    }

    private void OnMainMenuButtonClick()
    {
        _mediator.GoToMainMenu();
    }

    private void OnLevelSelectionButtonClick()
    {
        _mediator.GoToLevelSelectionMenu();
    }

    public override void Open()
    {
        base.Open();

        _view.Open();
    }

    public override void Close()
    {
        _view.Close(() => 
        {
            base.Close();
            _mediator.Unpause();
        });
    }

    private void OnDisable()
    {
        _levelSelectionButton.onClick.RemoveListener(OnLevelSelectionButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _closeButton.onClick.RemoveListener(OnCloseButtonClick);
    }
}
