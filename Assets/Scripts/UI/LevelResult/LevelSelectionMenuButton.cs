using Zenject;

public class LevelSelectionMenuButton : SimpleButton
{
    private ISceneLoadMediator _mediator;

    [Inject]
    private void Initialize(ISceneLoadMediator mediator)
    {
        _mediator = mediator;
    }

    protected override void Click()
    {
        _mediator.GoToLevelSelectionMenu();
    }
}
