using System;

[Serializable]
public class AdventureSaveData
{
    private const int MinLevelsCount = 1;

    public int CompleteLevels = 0;
    public int LevelsCount = MinLevelsCount;

    public int MinimumLevelsCount => MinLevelsCount;
}
