public interface ILevelSelectionMediator 
{
    public void OpenAdventureSelectionMenu();
    public void OpenLevelSelectionMenu();
    public void SetLevelSelectionTitleText();
    public void SetAdventureSelectionTitleText();
    public void SendAdventureConfig(AdventureConfig adventureConfig);
    public void SendLevelConfig(LevelConfig levelConfig);
    public void SendQuestionsCategory(QuestionsCategorie questionsCategorie);
    public void FillLevelsGrid(AdventureConfig adventureConfig);
    public void FillQuestionsCategoriesGrid(QuestionsCategorie[] questionCategories);
    public void ClearLevelsGrid();
    public void ClearQuestionsCategoriesGrid();
}
