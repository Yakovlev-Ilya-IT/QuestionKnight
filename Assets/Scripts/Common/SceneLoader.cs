using UnityEngine;

public class SceneLoader: ILevelLoader, ISimpleSceneLoader
{
    private ZenjectSceneLoaderWrapper _zenjectSceneLoader;

    public SceneLoader(ZenjectSceneLoaderWrapper zenjectSceneLoader)
    {
        _zenjectSceneLoader = zenjectSceneLoader;
    }

    public void Load(AdventureConfig adventureConfig, LevelConfig levelConfig, QuestionsCategorie questionsCategorie)
    {
        _zenjectSceneLoader.Load(container =>
        {
            container.BindInstance(adventureConfig).WhenInjectedInto<ConfigsInstaller>();
            container.BindInstance(levelConfig).WhenInjectedInto<ConfigsInstaller>();
            container.BindInstance(questionsCategorie).WhenInjectedInto<ConfigsInstaller>();
        }, (int)SceneID.StandartLevel);
    }

    public void Load(SceneID sceneId)
    {
        if(sceneId == SceneID.StandartLevel)
        {
            Debug.LogError($"{SceneID.StandartLevel} cannot be started without configuration, use ILevelLoader");
            return;
        }

        _zenjectSceneLoader.Load(null, (int)sceneId);
    }
}
