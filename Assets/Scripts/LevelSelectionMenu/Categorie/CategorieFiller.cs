using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CategorieFiller : MonoBehaviour
{
    [SerializeField] private CategorieSelectionButton _categorieButtonPrefab;
    [SerializeField] private GridLayoutGroup _grid;

    private const int DefaultCategorieButtonIndex = 0;

    private List<CategorieSelectionButton> _categorieSelectionButtons;

    private readonly Dictionary<QuestionsCategorie, string> _questionCategorieToCategorieName = new Dictionary<QuestionsCategorie, string>()
    {
        {QuestionsCategorie.Literature, "Литература"},
        {QuestionsCategorie.Music, "Музыка"},
        {QuestionsCategorie.Mathematics, "Математика"},
        {QuestionsCategorie.RussianLanguage, "Русский язык"},
        {QuestionsCategorie.Medicine, "Медицина"}
    };

    private ILevelSelectionMediator _mediator;

    [Inject]
    public void Construct(ILevelSelectionMediator mediator)
    {
        _mediator = mediator;
    }

    public void Fill(QuestionsCategorie[] questionCategories)
    {
        _categorieSelectionButtons = new List<CategorieSelectionButton>();
        List<ISelectable> selectables = new List<ISelectable>();

        for (int i = 0; i < questionCategories.Length; i++)
        {
            CategorieSelectionButton categorieSelectionButton = Instantiate(_categorieButtonPrefab, _grid.transform);
            categorieSelectionButton.Initialize(questionCategories[i], _questionCategorieToCategorieName[questionCategories[i]], _mediator);

            if (i == DefaultCategorieButtonIndex)
            {
                _mediator.SendQuestionsCategory(questionCategories[i]);
                categorieSelectionButton.Select();
            }

            _categorieSelectionButtons.Add(categorieSelectionButton);
            selectables.Add(categorieSelectionButton);
        }

        SelectionHandler buttonSelectionHandler = new SelectionHandler(selectables);
    }

    public void Clear()
    {
        foreach (var button in _categorieSelectionButtons)
        {
            Destroy(button.gameObject);
        }

        _categorieSelectionButtons.Clear();
    }
}
