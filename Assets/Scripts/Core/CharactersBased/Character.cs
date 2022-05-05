using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class Character : MonoBehaviour
{
    protected Health _health;
    [SerializeField] private StatusBar _healthBar;

    protected int _attackDamage;
    protected IDamageable _target;

    [SerializeField] private CharacterView _view;

    public event Action ProtectionStageIsOver;
    public event Action Died;

    public void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void Initialize(int maxHealth, int attackDamage)
    {
        _health = GetComponent<Health>();
        _health.Init(maxHealth, _healthBar);
        _health.HealthPointsIsOver += OnDied;
        _health.GotDamage += OnGotDamage;

        _attackDamage = attackDamage;

        _view.Initialize(this);
        _view.DeathAnimationFinished += OnDeathAnimationFinished;
        _view.AttackAnimationFinished += OnAttackAnimationFinished;
    }

    public void Initialize(int maxHealth, int attackDamage, IDamageable target)
    {
        Initialize(maxHealth, attackDamage);
        _target = target;
    }

    public void SpawnTo(Vector3 point)
    {
        transform.position = point;
    }

    public void DealDamage()
    {
        _view.Attack();
    }

    private void OnGotDamage(float currentHealth)
    {
        if (currentHealth > 0)
        {
            _view.Hurt();
            ProtectionStageIsOver?.Invoke();
        }
    }

    protected virtual void OnDied()
    {
        _view.Die();
    }

    protected virtual void OnDeathAnimationFinished()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }

    protected virtual void OnAttackAnimationFinished() 
    {
        if (_target != null)
            _target.TakeDamage(_attackDamage);
        else
            Debug.LogError("Target is not set");
    }

    private void OnDisable()
    {
        _view.DeathAnimationFinished -= OnDeathAnimationFinished;
        _view.AttackAnimationFinished -= OnAttackAnimationFinished;

        _health.HealthPointsIsOver -= OnDied;
        _health.GotDamage -= OnGotDamage;
    }
}
