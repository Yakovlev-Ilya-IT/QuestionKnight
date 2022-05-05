using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "PlayerStatsConfig", menuName = "Player/StatsConfig")]
public class PlayerStatsConfig : ScriptableObject
{
    [SerializeField, Range(0, 150)] private int _maxHealth;
    [SerializeField, Range(0, 100)] private int _attackDamage;

    public int MaxHealth => _maxHealth;
    public int AttackDamage => _attackDamage;
}
