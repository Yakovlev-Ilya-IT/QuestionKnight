using UnityEngine;

public class CristallRotator : Rotator
{
    [SerializeField] private float _returnRotateSpeed;
    [SerializeField] private float _rotateAccelerationMultiplier;

    private new void Update()
    {
        base.Update();

        if (_rotateSpeed > _startRotateSpeed)
            RecoverRotateSpeed();
    }

    private void RecoverRotateSpeed()
    {
        _rotateSpeed -= _returnRotateSpeed * Time.deltaTime;
    }

    public void AccelerateRotation()
    {
        _rotateSpeed = _startRotateSpeed * _rotateAccelerationMultiplier;
    }
}
