using System;

public abstract class SelectionButton : SimpleButton, ISelectable
{
    public event Action<ISelectable> Selected;

    public abstract void Select();

    public abstract void Unselect();

    protected override void Click()
    {
        if (_isLock)
            return;

        Selected?.Invoke(this);
    }
}
