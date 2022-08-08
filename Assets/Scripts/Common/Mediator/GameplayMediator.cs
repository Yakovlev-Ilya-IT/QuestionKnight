using UnityEngine;

public class GameplayMediator : MonoBehaviour, IGameplayMediator
{
    [SerializeField] private WinPanel _levelWinPanel;
    [SerializeField] private LoosePanel _levelLoosePanel;

    public void CloseMenu()
    {
        throw new System.NotImplementedException();
    }

    public void OpenMenu()
    {
        throw new System.NotImplementedException();
    }

    public void ShowLevelLoosePanel() => _levelLoosePanel.Open();

    public void ShowLevelWinPanel() => _levelWinPanel.Open();
}
