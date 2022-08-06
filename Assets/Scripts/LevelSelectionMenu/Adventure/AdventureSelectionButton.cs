using UnityEngine; 

public class AdventureSelectionButton : SimpleButton
{
    private AdventureConfig _config;
    [SerializeField] private AdventureSelectionButtonView _view;

    public void Initialize(AdventureConfig config)
    {
        _config = config;

        _view.Initialize(config.AdventureNumber, config.PercentageCompletion);
    }

    protected override void Click()
    {
        LevelSelectionEventsHolder.SendAdventureSelected(_config);
    }
}
