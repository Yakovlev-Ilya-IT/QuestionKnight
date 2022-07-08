using System;

public class LevelSelectionEventsHolder
{
    public static event Action<LevelConfig, SceneID> LevelSelected;

    public static void SendLevelSelected(LevelConfig levelConfig, SceneID id)
    {
        LevelSelected?.Invoke(levelConfig, id);
    }
}
