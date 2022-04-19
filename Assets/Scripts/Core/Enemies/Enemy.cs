using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private int _maxHealth;
    private int _currentHealth;
    private int _attackDamage;

    private Player _player;

    [SerializeField] private EnemyView _view;

    public void Initialize(int maxHealth, int attackDamage, Player player)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
        _attackDamage = attackDamage;
        _player = player;

        _view.Initialize(this);
    }

    

    public void SpawnTo(Vector3 point)
    {
        transform.position = point;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
    }

    public void DealDamage()
    {
        _view.Attack();
    }

    //опхдслюи я щрхл врн-рн (врн аш спнм мюмняхкяъ мнплюкэмн б яннрберярбхх я юмхлюжхеи
    public void Attack()
    {
        _player.TakeDamage(_attackDamage);
    }
}
