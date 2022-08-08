using UnityEngine;

public class WinPanelView : LevelResultWindowView
{
    [SerializeField] private string _levelCompleteTitle;
    [SerializeField] private string _adventureCompleteTitle;

    public void Initialize()
    {
        SetLevelCompleteTitle();
    }

    public void SetLevelCompleteTitle()
    {
        _titleText = _levelCompleteTitle;
    }

    public void SetAdventureCompleteTitle()
    {
        _titleText = _adventureCompleteTitle;
    }
}
