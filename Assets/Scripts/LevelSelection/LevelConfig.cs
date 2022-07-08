using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Game/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private EnemyWave _enemyWave;

    public EnemyWave EnemyWave => _enemyWave;
}
