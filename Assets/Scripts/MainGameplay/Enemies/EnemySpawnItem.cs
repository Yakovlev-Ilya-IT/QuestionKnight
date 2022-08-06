using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnItem
{
    [SerializeField] private EnemyFactory _factory;

    [SerializeField] private EnemyType _type;

    public EnemyFactory Factory => _factory;
    public EnemyType Type => _type;
}
