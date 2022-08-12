using UnityEngine;
using Zenject;

public class GameplayMediator : MonoBehaviour, IGameplayMediator
{
    [SerializeField] private WinPanel _levelWinPanel;
    [SerializeField] private LoosePanel _levelLoosePanel;
    [SerializeField] private PausePanel _pausedPanel;

    private PauseHandler _pauseHandler;
    private LevelsDataProvider _levelsDataProvider;
    private ISceneLoadMediator _sceneLoadMediator;
    private ConfigsHolder _configsHolder;

    [Inject]
    private void Initialize(PauseHandler pauseHandler, LevelsDataProvider levelsDataProvider, ISceneLoadMediator sceneLoadMediator, ConfigsHolder configsHolder)
    {
        _pauseHandler = pauseHandler;
        _levelsDataProvider = levelsDataProvider;
        _sceneLoadMediator = sceneLoadMediator;
        _configsHolder = configsHolder;
    }

    public void Unpause() => _pauseHandler.SetPause(false);
    public void Pause() => _pauseHandler.SetPause(true);
    public void ShowLevelLoosePanel() => _levelLoosePanel.Open();
    public void ShowLevelWinPanel() => _levelWinPanel.Open();
    public void ShowPausePanel() => _pausedPanel.Open();
    public void HidePausePanel() => _pausedPanel.Close();
    public void GoToMainMenu() => _sceneLoadMediator.GoToMainMenu();
    public void GoToLevelSelectionMenu() => _sceneLoadMediator.GoToLevelSelectionMenu();
    public void RestartLevel() => _sceneLoadMediator.GoToLevel(_configsHolder.AdventureConfig, _configsHolder.LevelConfig, _configsHolder.QuestionsCategorie);
    public bool TryLoadNextLevel(out LevelConfig levelConfig) => _levelsDataProvider.TryLoadLevel(_configsHolder.AdventureConfig.AdventureNumber, _configsHolder.LevelConfig.LevelNumber + 1, out levelConfig);
    public void GoToNextLevel()
    {
        if (TryLoadNextLevel(out LevelConfig levelConfig))
        {
            _sceneLoadMediator.GoToLevel(_configsHolder.AdventureConfig, levelConfig, _configsHolder.QuestionsCategorie);
            return;
        }
        Debug.LogError("NextLevel is empty");
    }
}
