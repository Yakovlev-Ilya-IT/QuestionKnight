using UnityEngine;

public class LevelSelectionButton : SelectionButton
{
    private LevelConfig _levelConfig;
    [SerializeField] private LevelSelectionButtonView _view;

    private LevelConfig LevelConfig => _levelConfig;
    
    private ILevelSelectionMediator _mediator;

    public void Initialize(LevelConfig levelConfig, string levelNumber, ILevelSelectionMediator mediator)
    {
        _levelConfig = levelConfig;
        _mediator = mediator;
        _view.Initialize(levelNumber);
    }

    protected override void Click()
    {
        base.Click();

        _mediator.SendLevelConfig(_levelConfig);
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
