using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Game/LevelConfig")]
public class LevelConfig : ScriptableObject, ISaveable
{
    [SerializeField] private int _adventureNumber;
    [SerializeField] private int _levelNumber;

    [SerializeField] private EnemyWave _enemyWave;

    private LevelSaveData _saveData = new LevelSaveData();

    public int LevelNumber => _levelNumber;

    public EnemyWave EnemyWave => _enemyWave;

    public object SaveableObject => _saveData;
    

    public LevelStatus LevelStatus
    {
        get => _saveData.LevelStatus;
        set => _saveData.LevelStatus = value;
    }

    public string GetFileName()
    {
        return $"Adventure{_adventureNumber}Level{_levelNumber}.json";
    }
}
