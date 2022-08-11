using UnityEngine;
using Zenject;

public class GameplayMediator : MonoBehaviour, IGameplayMediator
{
    [SerializeField] private WinPanel _levelWinPanel;
    [SerializeField] private LoosePanel _levelLoosePanel;
    [SerializeField] private PausePanel _pausedPanel;

    private PauseHandler _pauseHandler;

    [Inject]
    private void Initialize(PauseHandler pauseHandler)
    {
        _pauseHandler = pauseHandler;
    }

    public void Unpause() => _pauseHandler.SetPause(false);
    public void Pause() => _pauseHandler.SetPause(true);
    public void ShowLevelLoosePanel() => _levelLoosePanel.Open();
    public void ShowLevelWinPanel() => _levelWinPanel.Open();
    public void ShowPausePanel() => _pausedPanel.Open();
    public void HidePausePanel() => _pausedPanel.Close();   
}
