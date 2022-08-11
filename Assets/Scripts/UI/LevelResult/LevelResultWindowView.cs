using DG.Tweening;
using UnityEngine;

public abstract class LevelResultWindowView : WindowView
{
    [SerializeField] private TypeWriter _title;
    
    protected string _titleText;

    public override void Open(TweenCallback callback = null)
    {
        base.Open(callback);

        _title.Write(_titleText);
    }
}
