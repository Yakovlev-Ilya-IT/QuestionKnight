using UnityEngine;

public class CategorieSelectionButton : SelectionButton
{
    private QuestionsCategorie _questionsCategorie;
    [SerializeField] private CategorieSelectionButtonView _view;

    private ILevelSelectionMediator _mediator;

    public void Initialize(QuestionsCategorie questionsCategorie, string questionsCategorieName, ILevelSelectionMediator mediator)
    {
        _questionsCategorie = questionsCategorie;
        _mediator = mediator;
        _view.Initialize(questionsCategorieName);
    }

    protected override void Click()
    {
        base.Click();

        _mediator.SendQuestionsCategory(_questionsCategorie);
    }

    public override void Select()
    {
        if (_isLock)
            return;

        _view.Select();
    }

    public override void Unselect()
    {
        if (_isLock)
            return;

        _view.Unselect();
    }
}
