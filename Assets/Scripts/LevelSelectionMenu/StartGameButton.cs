using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class StartGameButton : MonoBehaviour, IPointerClickHandler
{
    private AdventureConfig _adventureConfig;
    private LevelConfig _levelConfig;
    private QuestionsCategorie _questionsCategorie;

    private ISceneLoadMediator _sceneLoadMediator;

    [Inject]
    private void Initialize(ISceneLoadMediator sceneLoadMediator)
    {
        _sceneLoadMediator = sceneLoadMediator;
    }

    private void OnEnable()
    {
        LevelSelectionEventsHolder.AdventureSelected += OnAdventureSelected;
        LevelSelectionEventsHolder.LevelSelected += OnLevelSelected;
        LevelSelectionEventsHolder.QuestionsCategorieSelected += OnQuestionsCategorieSelected;
    }

    private void OnAdventureSelected(AdventureConfig adventureConfig)
    {
        _adventureConfig = adventureConfig;
    }

    public void OnLevelSelected(LevelConfig levelConfig)
    {
        _levelConfig = levelConfig;
    }

    public void OnQuestionsCategorieSelected(QuestionsCategorie questionsCategorie)
    {
        _questionsCategorie = questionsCategorie;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_levelConfig != null || _adventureConfig != null)
            _sceneLoadMediator.GoToLevel(_adventureConfig, _levelConfig, _questionsCategorie);  
        else
            Debug.LogError("Some of config not selected");
    }

    private void OnDisable()
    {
        LevelSelectionEventsHolder.AdventureSelected -= OnAdventureSelected;
        LevelSelectionEventsHolder.LevelSelected -= OnLevelSelected;
        LevelSelectionEventsHolder.QuestionsCategorieSelected -= OnQuestionsCategorieSelected;
    }
}
