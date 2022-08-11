using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class CharacterView : MonoBehaviour
{
    protected Animator _animator;
    protected Character _character;

    protected const string HURT_KEY = "HURT";
    protected const string DIED_KEY = "DIED";
    protected const string ATTACK_KEY = "ATTACK";

    public event Action DeathAnimationFinished;
    public event Action AttackAnimationFinished;

    public void Initialize(Character character)
    {
        _animator = GetComponent<Animator>();
        _character = character;
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

    public void SetSpeedFactor(float factor)
    {
        _animator.speed = factor;
    }
}
