using System.Collections.Generic;

public class SelectionHandler
{
    private List<ISelectable> _selectables;

    public SelectionHandler(List<ISelectable> selectables)
    {
        _selectables = selectables;

        foreach (var selectable in _selectables)
            selectable.Selected += OnSelected;
    }

    public void OnSelected(ISelectable levelSelectionButton)
    {
        foreach (var selectable in _selectables)
        {
            if(selectable == levelSelectionButton)
                selectable.Select();
            else
                selectable.Unselect();
        }
    }

    ~SelectionHandler()
    {
        foreach (var selectable in _selectables)
            selectable.Selected -= OnSelected;
    }
}
