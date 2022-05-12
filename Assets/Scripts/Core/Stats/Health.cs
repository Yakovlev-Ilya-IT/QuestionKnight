using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _maxHealth;
    private int _currentHealth;

    public event Action<float> GotDamage;
    public event Action HealthPointsIsOver;

    private StatusBar _healthBar;

    public void Init(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
    }

    public void Init(int maxHealth, StatusBar healthBar)
    {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;

        _healthBar = healthBar;
        _healthBar.Init();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        GotDamage?.Invoke((float)_currentHealth / _maxHealth);

        if(_healthBar != null)
        _healthBar.SetFilling((float)_currentHealth / _maxHealth);

        if (_currentHealth <= 0)
        {
            HealthPointsIsOver?.Invoke();
        }
    }
}