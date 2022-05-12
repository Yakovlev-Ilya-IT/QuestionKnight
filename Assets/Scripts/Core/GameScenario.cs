using UnityEngine;

[CreateAssetMenu (fileName = "GameScenario", menuName = "Game/Scenario")]
public class GameScenario : ScriptableObject
{
    [SerializeField] private EnemySpawnItem[] _spawnItems;

    private Transform _spawnPoint;

    private Player _player;

    private int _index;

    public Enemy CurrentEnemy { get; private set; }

    public void Init(Transform spawnPoint, Player player)
    {
        _spawnPoint = spawnPoint;
        _player = player;
        _index = 0;
    }

    public bool Progress()
    {
        if(CurrentEnemy == null)
        {
            if(_index > _spawnItems.Length - 1)
            {
                return false;
            }

            CurrentEnemy = _spawnItems[_index].Factory.Get(_spawnItems[_index].Type, _player, this);
            CurrentEnemy.SpawnTo(_spawnPoint.position);

            _player.SetNewTarget(CurrentEnemy);

            _index++;
            return true;
        }

        return true;
    } 

    public void Recycle()
    {
        CurrentEnemy = null; 
    }
}
