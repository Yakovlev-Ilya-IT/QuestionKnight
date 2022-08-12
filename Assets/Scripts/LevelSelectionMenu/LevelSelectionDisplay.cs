using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelSelectionDisplay : Window
{
    private LevelSelectionButton[] _levelSelectionButtons;
    private CategorieSelectionButton[] _categorieSelectionButtons;

    [SerializeField] private Button _backButton;
    [SerializeField] private Button _playButton;
    
    [SerializeField] private LevelsGridBuilder _levelsGridBuilder;
    [SerializeField] private CategoriesGridBuilder _categoriesGridBuilder;

    private ILevelSelectionMediator _levelSelectionMediator;    

    [Inject]
    private void Construct(ILevelSelectionMediator levelSelectionMediator)
    {
        _levelSelectionMediator = levelSelectionMediator;
    }

    public void Open(AdventureConfig adventureConfig)
    {
        Open();

        _levelSelectionButtons = _levelsGridBuilder.Build(adventureConfig);
        _categorieSelectionButtons = _categoriesGridBuilder.Build(adventureConfig.QuestionsCategories);

        _levelSelectionMediator.SetLevelSelectionTitleText();
        _levelSelectionMediator.SendAdventureConfig(adventureConfig);

        Subscribe();
    }

    public override void Close()
    {
        base.Close();

        UnSubscribe();

        _levelsGridBuilder.Clear(_levelSelectionButtons);
        _categoriesGridBuilder.Clear(_categorieSelectionButtons);
    }

    private void OnBackButtonClick()
    {
        _levelSelectionMediator.OpenAdventureSelectionDisplay();
    }

    private void OnPlayButtonClick()
    {
        _levelSelectionMediator.GoToSelectLevel();
    }

    private void OnCategorieSelectionButtonPressed(QuestionsCategorie categorie)
    {
        _levelSelectionMediator.SendQuestionsCategory(categorie);
    }

    private void OnLevelSelectionButtonPressed(LevelConfig config)
    {
        _levelSelectionMediator.SendLevelConfig(config);
    }

    private void Subscribe()
    {
        _backButton.onClick.AddListener(OnBackButtonClick);
        _playButton.onClick.AddListener(OnPlayButtonClick);

        foreach (LevelSelectionButton button in _levelSelectionButtons)
            button.Pressed += OnLevelSelectionButtonPressed;

        foreach (CategorieSelectionButton button in _categorieSelectionButtons)
            button.Pressed += OnCategorieSelectionButtonPressed;

    }

    private void UnSubscribe()
    {
        _backButton.onClick.RemoveListener(OnBackButtonClick);
        _playButton.onClick.RemoveListener(OnPlayButtonClick);

        foreach (LevelSelectionButton button in _levelSelectionButtons)
            button.Pressed -= OnLevelSelectionButtonPressed;

        foreach (CategorieSelectionButton button in _categorieSelectionButtons)
            button.Pressed -= OnCategorieSelectionButtonPressed;
    }
}
