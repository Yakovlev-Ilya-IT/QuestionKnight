public class SelectedLevelLoader
{
    private SceneLoader _sceneLoader;

    public SelectedLevelLoader(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
        LevelSelectionEventsHolder.LevelSelected += Load;
    }

    public void Load(LevelConfig levelConfig, SceneID id)
    {
        _sceneLoader.Load(container =>
        {
            container.BindInstance(levelConfig.EnemyWave).WhenInjectedInto<EnemySpawnSystemInstaller>();
        }, (int)id);
    }

    ~SelectedLevelLoader()
    {
        LevelSelectionEventsHolder.LevelSelected -= Load;
    }
}
