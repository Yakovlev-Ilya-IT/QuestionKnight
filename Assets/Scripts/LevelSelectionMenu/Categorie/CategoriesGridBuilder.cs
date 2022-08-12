using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CategoriesGridBuilder : MonoBehaviour
{
    [SerializeField] private CategorieSelectionButton _categorieButtonPrefab;
    [SerializeField] private GridLayoutGroup _grid;

    private const int DefaultCategorieButtonIndex = 0;

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

    public CategorieSelectionButton[] Build(QuestionsCategorie[] questionCategories)
    {
        CategorieSelectionButton[]  categorieSelectionButtons = new CategorieSelectionButton[questionCategories.Length];
        List<ISelectable> selectables = new List<ISelectable>();

        for (int i = 0; i < questionCategories.Length; i++)
        {
            CategorieSelectionButton categorieSelectionButton = Instantiate(_categorieButtonPrefab, _grid.transform);
            InitializeButton(categorieSelectionButton, i, questionCategories[i], _questionCategorieToCategorieName[questionCategories[i]]);

            categorieSelectionButtons[i] = categorieSelectionButton;
            selectables.Add(categorieSelectionButton);
        }

        SelectionHandler buttonSelectionHandler = new SelectionHandler(selectables);

        return categorieSelectionButtons;
    }

    private void InitializeButton(CategorieSelectionButton button, int categorieNumber, QuestionsCategorie categorie, string categorieName)
    {
        button.Initialize(categorie, categorieName);

        if (categorieNumber == DefaultCategorieButtonIndex)
        {
            _mediator.SendQuestionsCategory(categorie);
            button.Select();
        }
    }

    public void Clear(CategorieSelectionButton[] buttons)
    {
        foreach (var button in buttons)
        {
            Destroy(button.gameObject);
        }
    }
}
