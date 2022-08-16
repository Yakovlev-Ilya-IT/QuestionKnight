using UnityEngine;
using Zenject;

public class SceneLoadMediator : MonoBehaviour, ISceneLoadMediator
{
    private ILevelLoader _levelLoader;
    private ISimpleSceneLoader _simpleSceneLoader;

    [Inject]
    private void Construct(ILevelLoader levelLoader, ISimpleSceneLoader simpleSceneLoader)
    {
        _levelLoader = levelLoader;
        _simpleSceneLoader = simpleSceneLoader;
    }

    public void GoToLevelSelectionMenu() => _simpleSceneLoader.Load(SceneID.LevelSelectionMenu);
    public void GoToMainMenu() => _simpleSceneLoader.Load(SceneID.MainMenu);
    public void GoToLevel(AdventureConfig adventureConfig, LevelConfig levelConfig, QuestionsCategorie questionsCategorie) => _levelLoader.Load(adventureConfig, levelConfig, questionsCategorie);
}
