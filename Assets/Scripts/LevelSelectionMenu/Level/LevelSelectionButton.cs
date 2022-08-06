using UnityEngine;

public class LevelSelectionButton : SelectionButton
{
    private LevelConfig _levelConfig;
    [SerializeField] private LevelSelectionButtonView _view;

    private LevelConfig LevelConfig => _levelConfig;

    public void Initialize(LevelConfig levelConfig, string levelNumber)
    {
        _levelConfig = levelConfig;
        _view.Initialize(levelNumber);
    }

    protected override void Click()
    {
        base.Click();

        LevelSelectionEventsHolder.SendLevelSelected(_levelConfig);
    }

    public override void Lock()
    {
        base.Lock();

        _view.Lock();
    }

    public override void Unlock()
    {
        base.Unlock();

        _view.Unlock();
    }

    public override void Select()
    {
        if (_isLock)
            return;

        _view.Select();
    }

    public override void Unselect()
    {
        if (_isLock)
            return;

        _view.Unselect();
    }
}
