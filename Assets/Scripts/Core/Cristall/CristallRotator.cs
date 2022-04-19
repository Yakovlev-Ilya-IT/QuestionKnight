using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristallRotator : MonoBehaviour
{
    [SerializeField] private float _startRotateSpeed;
    private float _rotateSpeed;
    [SerializeField] private float _returnRotateSpeed;
    [SerializeField] private float _rotateAccelerationMultiplier;


    private Vector3 _directionOfAxisRotation;

    public void Init(Vector3 angle)
    {
        _rotateSpeed = _startRotateSpeed;

        _directionOfAxisRotation = new Vector3(Random.value, Random.value, Random.value);
        _directionOfAxisRotation.Normalize();

        transform.eulerAngles = angle;
    }


    private void Update()
    {
        Rotate();

        if (_rotateSpeed > _startRotateSpeed)
            RecoverRotateSpeed();
    }

    private void Rotate()
    {
        transform.RotateAround(transform.position, _directionOfAxisRotation, _rotateSpeed * Time.deltaTime);
    }

    private void RecoverRotateSpeed()
    {
        _rotateSpeed -= _returnRotateSpeed * Time.deltaTime;
    }

    public void SetRotationDirection(Vector3 direction)
    {
        _directionOfAxisRotation = Vector3.Cross(direction, Vector3.forward);
    }

    public void AccelerateRotation()
    {
        _rotateSpeed = _startRotateSpeed * _rotateAccelerationMultiplier;
    }
}
