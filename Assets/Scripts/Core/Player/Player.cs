using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(5,100)] private int _maxHealth;
    private int _currentHealth;
    [SerializeField, Range(5,20)]private int _attackDamage;

    private Player _player;

    GameScenario _gameScenario;

    [SerializeField] private PlayerView _view;

    public int CurrentHealth => _currentHealth;

    public event Action AttackHasEnded;
    public event Action ApplyDamageFinished;

    public void Initialize(GameScenario gameScenario)
    {
        _currentHealth = _maxHealth;
        _gameScenario = gameScenario;   


        _view.Initialize(this);

        _view.DeathAnimationFinished += OnDeathAnimationFinished;
        _view.AttackAnimationFinished += OnAttackAnimationFinished;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        _view.Hurt();
        Debug.Log(_currentHealth);
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
        ApplyDamageFinished?.Invoke();
        Destroy(gameObject);
    }

    private void OnAttackAnimationFinished()
    {
        _gameScenario.CurrentEnemy.ApplyDamage(_attackDamage);
        AttackHasEnded?.Invoke();
    }

    private void OnDisable()
    {
        _view.DeathAnimationFinished -= OnDeathAnimationFinished;
        _view.AttackAnimationFinished -= OnAttackAnimationFinished;
    }
}
