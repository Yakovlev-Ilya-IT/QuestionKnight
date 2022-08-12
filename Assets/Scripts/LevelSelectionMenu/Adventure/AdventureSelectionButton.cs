using System;
using UnityEngine;
public class AdventureSelectionButton : SimpleButton
{
    private AdventureConfig _config;
    [SerializeField] private AdventureSelectionButtonView _view;

    public event Action<AdventureConfig> Pressed;

    public void Initialize(AdventureConfig config)
    {
        _config = config;

        _view.Initialize(config.AdventureNumber, config.PercentageCompletion);
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

    protected override void Click()
    {
        Pressed?.Invoke(_config);
    }
}
