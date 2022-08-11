using DG.Tweening;
using UnityEngine;

public class PausePanelView : WindowView
{
    [SerializeField] private TypeWriter _title;
    [SerializeField] private string _titleText;

    public override void Open(TweenCallback callback = null)
    {
        base.Open(callback);

        _title.Write(_titleText);
    }
}
