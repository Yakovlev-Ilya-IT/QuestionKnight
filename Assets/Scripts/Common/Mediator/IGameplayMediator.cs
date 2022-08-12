public interface IGameplayMediator
{
    public void ShowLevelWinPanel();
    public void ShowLevelLoosePanel();
    public void ShowPausePanel();
    public void HidePausePanel();
    public void Pause();
    public void Unpause();
    public void GoToMainMenu();
    public void GoToLevelSelectionMenu();
    public void RestartLevel();
    public bool TryLoadNextLevel(out LevelConfig levelConfig);
    public void GoToNextLevel();
}
