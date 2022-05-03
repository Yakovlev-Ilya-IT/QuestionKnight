using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerView : MonoBehaviour
{
    protected Animator _animator;
    protected Player _enemy;

    protected const string HURT_KEY = "HURT";
    protected const string DIED_KEY = "DIED";
    protected const string ATTACK_KEY = "ATTACK";

    public event Action DeathAnimationFinished;
    public event Action AttackAnimationFinished;

    public virtual void Initialize(Player enemy)
    {
        _animator = GetComponent<Animator>();
        _enemy = enemy;
    }

    public virtual void Hurt()
    {
        _animator.SetTrigger(HURT_KEY);
    }

    public virtual void Die()
    {
        _animator.SetTrigger(DIED_KEY);
    }

    public virtual void Attack()
    {
        _animator.SetTrigger(ATTACK_KEY);
    }

    public virtual void OnDieAnimationComplete()
    {
        DeathAnimationFinished?.Invoke();
    }

    public virtual void OnAttackAnimationComplete()
    {
        AttackAnimationFinished?.Invoke();
    }
}
