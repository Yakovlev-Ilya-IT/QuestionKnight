using System;
using UnityEngine;

public class CategorieSelectionButton : SelectionButton
{
    private QuestionsCategorie _questionsCategorie;
    [SerializeField] private CategorieSelectionButtonView _view;

    public event Action<QuestionsCategorie> Pressed;

    public void Initialize(QuestionsCategorie questionsCategorie, string questionsCategorieName)
    {
        _questionsCategorie = questionsCategorie;
        _view.Initialize(questionsCategorieName);
    }

    protected override void Click()
    {
        base.Click();

        Pressed?.Invoke(_questionsCategorie);
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
