public interface ILevelSelectionMediator 
{
    public void OpenAdventureSelectionDisplay();
    public void OpenLevelSelectionDisplay(AdventureConfig adventureConfig);
    public void SetLevelSelectionTitleText();
    public void SetAdventureSelectionTitleText();
    public void GoToSelectLevel();
    public void SendAdventureConfig(AdventureConfig adventureConfig);
    public void SendLevelConfig(LevelConfig levelConfig);
    public void SendQuestionsCategory(QuestionsCategorie questionsCategorie);
}
