using System;
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

    private NextLevelHandler _nextLevelHandler;
    private ISceneLoadMediator _sceneLoadMediator;
    private IGameplayMediator _gameplayMediator;

    [Inject]
    protected void Initialize(ISceneLoadMediator sceneLoadMediator, IGameplayMediator gameplayMediator, NextLevelHandler nextLevelHandler)
    {
        _sceneLoadMediator = sceneLoadMediator;
        _gameplayMediator = gameplayMediator;
        _nextLevelHandler = nextLevelHandler;
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
        _gameplayMediator.HidePausePanel();
    }

    private void OnRestartButtonClick()
    {
        _sceneLoadMediator.GoToLevel(_nextLevelHandler.AdventureConfig, _nextLevelHandler.CurrentLevelConfig, _nextLevelHandler.QuestionsCategorie);
    }

    private void OnMainMenuButtonClick()
    {
        _sceneLoadMediator.GoToMainMenu();
    }

    private void OnLevelSelectionButtonClick()
    {
        _sceneLoadMediator.GoToLevelSelectionMenu();
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
            _gameplayMediator.Unpause();
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
