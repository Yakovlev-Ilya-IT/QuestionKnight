using System;

public interface ISelectable
{
    public event Action<ISelectable> Selected;
    public void Select();
    public void Unselect();
}