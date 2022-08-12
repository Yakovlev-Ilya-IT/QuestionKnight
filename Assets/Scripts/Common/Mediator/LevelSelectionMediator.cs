using UnityEngine;
using Zenject;

public class LevelSelectionMediator : MonoBehaviour, ILevelSelectionMediator
{
    [SerializeField] private AdventureSelectionDisplay _adventureSelectionDisplay;
    [SerializeField] private LevelSelectionDisplay _levelSelectionDisplay;
    [SerializeField] private SelectionMenuTitle _menuTitle;

    private ConfigsHolder _configsHolder;
    private ISceneLoadMediator _sceneLoadMediator;

    [Inject]
    private void Construct(ISceneLoadMediator sceneLoadMediator)
    {
        _configsHolder = new ConfigsHolder();
        _sceneLoadMediator = sceneLoadMediator;
    }

    public void OpenAdventureSelectionDisplay()
    {
        _adventureSelectionDisplay.Open();
        _levelSelectionDisplay.Close();
    }
    public void OpenLevelSelectionDisplay(AdventureConfig adventureConfig)
    {
        _levelSelectionDisplay.Open(adventureConfig);
        _adventureSelectionDisplay.Close();
    }

    public void SetAdventureSelectionTitleText() => _menuTitle.SetAdventureSelectionText();
    public void SetLevelSelectionTitleText() => _menuTitle.SetLevelSelectionText();
    public void SendAdventureConfig(AdventureConfig adventureConfig) => _configsHolder.AdventureSelect(adventureConfig);
    public void SendLevelConfig(LevelConfig levelConfig) => _configsHolder.LevelSelect(levelConfig);
    public void SendQuestionsCategory(QuestionsCategorie questionsCategorie) => _configsHolder.QuestionsCategorieSelect(questionsCategorie);
    public void GoToSelectLevel() => _sceneLoadMediator.GoToLevel(_configsHolder.AdventureConfig, _configsHolder.LevelConfig, _configsHolder.QuestionsCategorie);
}
