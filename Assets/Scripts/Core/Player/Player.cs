using UnityEngine;

public class Player : Character
{
    public void SetNewTarget(IDamageable target)
    {
        _target = target;
    }
}
