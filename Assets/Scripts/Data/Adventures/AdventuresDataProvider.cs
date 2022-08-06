using UnityEngine;

public class AdventuresDataProvider
{
    private ISaver _saver;

    private const string Path = @"AdventureConfigs";

    public AdventuresDataProvider(ISaver saver)
    {
        _saver = saver;
    }

    public AdventureConfig[] Load()
    {
        AdventureConfig[] adventureConfigs = Resources.LoadAll<AdventureConfig>(Path);

        InitData(adventureConfigs);

        return adventureConfigs;
    }

    private void InitData(AdventureConfig[] adventureConfigs)
    {
        foreach (var adventure in adventureConfigs)
        {
            if (_saver.IsFileExist(adventure))
            {
                _saver.Load(adventure);
            }
        }
    }
}
