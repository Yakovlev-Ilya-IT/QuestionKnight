using UnityEngine;

public class LevelsDataProvider
{
    private ISaver _saver;

    private const string Path = @"LevelConfigs/Adventure";

    public LevelsDataProvider(ISaver saver)
    {
        _saver = saver;
    }

    public LevelConfig[] LoadAll(int adventureIndex)
    {
        LevelConfig[] levelConfigs = Resources.LoadAll<LevelConfig>(Path + adventureIndex.ToString());

        InitData(levelConfigs);

        return levelConfigs;
    }

    public bool TryLoadLevel(int adventureIndex, int levelNumber,out LevelConfig levelConfig)
    {
        levelConfig = Resources.Load<LevelConfig>(Path + $"{adventureIndex}/level{levelNumber}");

        if(levelConfig == null)
            return false;
        return true;
    }

    private void InitData(LevelConfig[] levelConfigs)
    {
        foreach (var level in levelConfigs)
        {
            if (_saver.IsFileExist(level))
            {
                _saver.Load(level);
            }
        }
    }
}
