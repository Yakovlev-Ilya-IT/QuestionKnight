using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "EnemyFactory", menuName = "Factories/Enemy")]
public class EnemyFactory : ScriptableObject
{
    [Serializable]
    private class EnemyConfig
    {
        public Enemy _enemyPrefab;
        [Range(0, 200)] public int Health = 100;
        [Range(0, 15)] public int Damage = 5;
        [Range(1, 50)] public float TimeToAnswer;
    }

    [SerializeField] private EnemyConfig _lightBandit, _heavyBandit;

    public Enemy Get(EnemyType type, DiContainer diContainer)
    {
        EnemyConfig config = GetConfig(type);
        Enemy instance = diContainer.InstantiatePrefabForComponent<Enemy>(config._enemyPrefab);
        instance.Initialize(config.Health, config.Damage, config.TimeToAnswer, diContainer.Resolve<Player>(), diContainer.Resolve<LevelScenario>());
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
