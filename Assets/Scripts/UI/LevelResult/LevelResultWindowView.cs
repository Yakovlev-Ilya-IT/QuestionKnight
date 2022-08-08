using UnityEngine;

public abstract class LevelResultWindowView : WindowView
{
    [SerializeField] private TypeWriter _title;
    
    protected string _titleText;

    public override void Open()
    {
        base.Open();

        _title.Write(_titleText);
    }
}
