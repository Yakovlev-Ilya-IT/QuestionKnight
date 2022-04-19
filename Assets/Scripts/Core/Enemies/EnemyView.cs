using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class EnemyView : MonoBehaviour
{
    protected Animator _animator;
    protected Enemy _enemy;

    protected const string HURT_KEY = "HURT";
    protected const string DIED_KEY = "DIED";
    protected const string ATTACK_KEY = "ATTACK";

    public virtual void Initialize(Enemy enemy)
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

    //опхдслюи я щрхл врн-рн (врн аш спнм мюмняхкяъ мнплюкэмн б яннрберярбхх я юмхлюжхеи
    public void AttackDamage()
    {
        _enemy.Attack();
    }
}
