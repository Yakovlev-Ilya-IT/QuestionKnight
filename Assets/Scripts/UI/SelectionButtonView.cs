using UnityEngine;

public abstract class SelectionButtonView : SimpleButtonView
{
    [SerializeField] private Color _backgroundSelectionColor;

    public virtual void Select()
    {
        _background.color = _backgroundSelectionColor;
    }
    public virtual void Unselect()
    {
        _background.color = _backgroundStandartColor;
    }
}
