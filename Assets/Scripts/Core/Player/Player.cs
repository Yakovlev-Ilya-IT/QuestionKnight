using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    [SerializeField] Animator _animator;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _animator.SetTrigger("HURT");
        Debug.Log(_currentHealth);

        if(_currentHealth <= 0)
        {
            Debug.Log("YOU ARE DEATH");
        }
    }
}
