using Zenject;

public class BackToAdventuresButton : SimpleButton
{
    private ILevelSelectionMediator _mediator;

    [Inject]
    public void Construct(ILevelSelectionMediator mediator)
    {
        _mediator = mediator;
    }

    protected override void Click()
    {
        _mediator.SetAdventureSelectionTitleText();
        _mediator.ClearLevelsGrid();
        _mediator.ClearQuestionsCategoriesGrid();
        _mediator.OpenAdventureSelectionMenu();
    }
}
