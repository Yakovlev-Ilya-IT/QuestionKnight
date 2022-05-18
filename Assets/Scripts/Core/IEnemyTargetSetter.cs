using System;

public interface IEnemyTargetSetter
{
    public event Action<IDamageable> NewEnemyTargetHasBeenSet;
}