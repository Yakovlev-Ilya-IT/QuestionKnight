using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private int _maxHealth;
    private int _currentHealth;
    private int _attackDamage;

    private Player _player;
    private GameScenario _scenario;

    [SerializeField] private EnemyView _view;

    public event Action ApplyDamageFinished;

    public void Initialize(int maxHealth, int attackDamage, Player player, GameScenario scenario)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
        _attackDamage = attackDamage;
        _player = player;
        _scenario = scenario;

        _view.Initialize(this);

        _view.DeathAnimationFinished += OnDeathAnimationFinished;
        _view.AttackAnimationFinished += OnAttackAnimationFinished;
    }

    public void SpawnTo(Vector3 point)
    {
        transform.position = point;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _view.Die();
        }
        else
        {
            _view.Hurt();
            ApplyDamageFinished?.Invoke();
        }
    }

    public void DealDamage()
    {
        _view.Attack();
    }

    private void OnDeathAnimationFinished()
    {
        _scenario.Recycle();
        ApplyDamageFinished?.Invoke();
        Destroy(gameObject);
    }

    private void OnAttackAnimationFinished()
    {
        _player.TakeDamage(_attackDamage);
    }

    private void OnDisable()
    {
        _view.DeathAnimationFinished -= OnDeathAnimationFinished;
        _view.AttackAnimationFinished -= OnAttackAnimationFinished;
    }
}
