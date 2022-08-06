public class LevelSaver
{
    private ISaver _saver;
    private LevelConfig _levelConfig;
    private AdventureConfig _adventureConfig;

    public LevelSaver(ISaver saver, LevelConfig levelConfig, AdventureConfig adventureConfig)
    {
        _saver = saver;
        _levelConfig = levelConfig;
        _adventureConfig = adventureConfig;
    }

    public void Save(LevelStatus levelStatus)
    {
        _levelConfig.LevelStatus = levelStatus;
        _saver.Save(_levelConfig);

        if(_levelConfig.LevelStatus == LevelStatus.LevelPassed && _adventureConfig.CompleteLevels < _levelConfig.LevelNumber)
        {
            _adventureConfig.CompleteLevels++;
            _saver.Save(_adventureConfig);
        }
    }
}
