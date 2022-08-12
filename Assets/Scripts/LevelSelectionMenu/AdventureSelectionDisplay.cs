using UnityEngine;
using Zenject;

public class AdventureSelectionDisplay : Window
{
    private AdventureSelectionButton[] _adventureSelectionButtons;
    [SerializeField] private AdventureButtonsFiller _adventuresFiller;
    private ILevelSelectionMediator _mediator;

    [Inject]
    public void Construct(ILevelSelectionMediator levelSelectionMediator)
    {
        _mediator = levelSelectionMediator;
    }

    private new void Awake()
    {
        base.Awake();    
        _adventureSelectionButtons = GetComponentsInChildren<AdventureSelectionButton>();

        _adventuresFiller.Fill(_adventureSelectionButtons);
    }

    private void OnEnable()
    {
        foreach (var button in _adventureSelectionButtons)
            button.Pressed += OnAdventureSelectionButtonPressed;
    }

    public override void Open()
    {
        base.Open();
        _mediator.SetAdventureSelectionTitleText();
    }

    private void OnAdventureSelectionButtonPressed(AdventureConfig config)
    {
        _mediator.OpenLevelSelectionDisplay(config);
    }

    private void OnDisable()
    {
        foreach (var button in _adventureSelectionButtons)
            button.Pressed -= OnAdventureSelectionButtonPressed;
    }
}
