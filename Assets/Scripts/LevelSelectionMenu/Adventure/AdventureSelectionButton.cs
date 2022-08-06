using UnityEngine;
using Zenject;

public class AdventureSelectionButton : SimpleButton
{
    private AdventureConfig _config;
    [SerializeField] private AdventureSelectionButtonView _view;

    private ILevelSelectionMediator _mediator;

    [Inject]
    private void Construct(ILevelSelectionMediator mediator)
    {
        _mediator = mediator;
    }

    public void Initialize(AdventureConfig config)
    {
        _config = config;

        _view.Initialize(config.AdventureNumber, config.PercentageCompletion);
    }

    protected override void Click()
    {
        _mediator.SendAdventureConfig(_config);
        _mediator.SetLevelSelectionTitleText();
        _mediator.FillLevelsGrid(_config);
        _mediator.FillQuestionsCategoriesGrid(_config.QuestionsCategories);
        _mediator.OpenLevelSelectionMenu();
    }
}
