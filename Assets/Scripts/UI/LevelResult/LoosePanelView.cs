using UnityEngine;

public class LoosePanelView : LevelResultWindowView
{
    [SerializeField] private string _levelDefeatTitle;
 
    public void Initialize()
    {
        _titleText = _levelDefeatTitle;
    }
}
