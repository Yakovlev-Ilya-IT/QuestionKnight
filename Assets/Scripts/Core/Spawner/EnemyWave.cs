using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "Game/EnemyWave")]
public class EnemyWave : ScriptableObject
{
    [SerializeField] private EnemySpawnItem[] _spawnItems;

    private int _index;

    public void Init()
    {
        _index = 0;
    }

    public bool TryGetNextSpawnItem(out EnemySpawnItem spawnItem)
    {
        if (_index > _spawnItems.Length - 1)
        {
            spawnItem = null;
            return false;
        }

        spawnItem = _spawnItems[_index];    

        _index++;

        return true;
    }
}
