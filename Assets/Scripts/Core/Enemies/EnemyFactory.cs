using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Factory", menuName = "Factories/Enemy")]
public class EnemyFactory : ScriptableObject
{
    [Serializable]
    private class EnemyConfig
    {
        public Enemy _enemyPrefab;
        [Range(0, 200)] public int Health = 100;
        [Range(0, 15)] public int Damage = 5;
    }

    [SerializeField] EnemyConfig _lightBandit, _heavyBandit;

    public Enemy Get(EnemyType type, Player player, GameScenario sccenario)
    {
        EnemyConfig config = GetConfig(type);
        Enemy instance = Instantiate(config._enemyPrefab);
        instance.Initialize(config.Health, config.Damage, player, sccenario);
        return instance;
    }

    private EnemyConfig GetConfig(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.lightBandit:
                return _lightBandit;
            case EnemyType.heavyBandit:
                return _heavyBandit; 
        }
        Debug.LogError($"No Config for {type}");
        return _lightBandit;
    }
}
