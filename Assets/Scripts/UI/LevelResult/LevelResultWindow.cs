using UnityEngine;
using UnityEngine.UI;

public abstract class LevelResultWindow : Window
{
    [SerializeField] protected Button _levelSelectionMenuButton;
    [SerializeField] protected Button _mainMenuButton;

    protected IGameplayMediator _mediator;

    protected void Initialize(IGameplayMediator mediator)
    {
        _mediator = mediator;
    }

    protected virtual void OnEnable()
    {
        _levelSelectionMenuButton.onClick.AddListener(OnLevelSelectionMenuButtonClick);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void OnLevelSelectionMenuButtonClick()
    {
        _mediator.GoToLevelSelectionMenu();
    }

    private void OnMainMenuButtonClick()
    {
        _mediator.GoToMainMenu();
    }

    protected virtual void OnDisable()
    {
        _levelSelectionMenuButton.onClick.RemoveListener(OnLevelSelectionMenuButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
    }
}
