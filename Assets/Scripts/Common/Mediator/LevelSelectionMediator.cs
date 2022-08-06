using UnityEngine;

public class LevelSelectionMediator : MonoBehaviour, ILevelSelectionMediator
{
    [SerializeField] private StartGameButton _startGameButton;
    [SerializeField] private Transform _adventureSelectionPanel;
    [SerializeField] private Transform _levelSelectionPanel;
    [SerializeField] private SelectionMenuTitle _menuTitle;
    [SerializeField] private LevelFiller _levelFiller;
    [SerializeField] private CategorieFiller _categorieFiller;

    public void OpenAdventureSelectionMenu()
    {
        _adventureSelectionPanel.gameObject.SetActive(true);
        _levelSelectionPanel.gameObject.SetActive(false);
    }
    public void OpenLevelSelectionMenu()
    {
        _adventureSelectionPanel.gameObject.SetActive(false);
        _levelSelectionPanel.gameObject.SetActive(true);
    }
    public void SendAdventureConfig(AdventureConfig adventureConfig) => _startGameButton.AdventureSelect(adventureConfig);
    public void SendLevelConfig(LevelConfig levelConfig) => _startGameButton.LevelSelect(levelConfig);
    public void SendQuestionsCategory(QuestionsCategorie questionsCategorie) => _startGameButton.QuestionsCategorieSelect(questionsCategorie);
    public void SetAdventureSelectionTitleText() => _menuTitle.SetAdventureSelectionText();
    public void SetLevelSelectionTitleText() => _menuTitle.SetLevelSelectionText();
    public void FillLevelsGrid(AdventureConfig adventureConfig) => _levelFiller.Fill(adventureConfig);
    public void FillQuestionsCategoriesGrid(QuestionsCategorie[] questionCategories) => _categorieFiller.Fill(questionCategories);
    public void ClearLevelsGrid() => _levelFiller.Clear();
    public void ClearQuestionsCategoriesGrid() => _categorieFiller.Clear();
}
