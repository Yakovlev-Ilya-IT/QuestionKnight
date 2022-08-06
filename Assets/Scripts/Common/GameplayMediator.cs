using UnityEngine;

public class GameplayMediator : MonoBehaviour, IGameplayMediator
{
    [SerializeField] private WinPanel _levelWinPanel;
    [SerializeField] private GameObject _levelLoosePanel;

    public void CloseMenu()
    {
        throw new System.NotImplementedException();
    }

    public void OpenMenu()
    {
        throw new System.NotImplementedException();
    }

    public void ShowLevelLoosePanel() => _levelLoosePanel.SetActive(true);

    public void ShowLevelWinPanel() => _levelWinPanel.Open();
}
