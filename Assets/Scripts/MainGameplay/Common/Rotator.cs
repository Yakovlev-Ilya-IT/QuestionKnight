using UnityEngine;
using Zenject;

public class Rotator : MonoBehaviour
{
    [SerializeField] protected float _startRotateSpeed;
    protected float _rotateSpeed;

    private Vector3 _directionOfAxisRotation;

    private bool _isStop;


    public void Initialize(Vector3 angle)
    {
        _rotateSpeed = _startRotateSpeed;

        _directionOfAxisRotation = new Vector3(Random.value, Random.value, Random.value);
        _directionOfAxisRotation.Normalize();

        transform.eulerAngles = angle;
    }

    protected void Update()
    {
        if (_isStop)
            return;

        Rotate();
    }

    private void Rotate()
    {
        transform.RotateAround(transform.position, _directionOfAxisRotation, _rotateSpeed * Time.deltaTime);
    }

    public void SetRotationDirection(Vector3 direction)
    {
        _directionOfAxisRotation = Vector3.Cross(direction, Vector3.forward);
    }

    public void SetStop(bool isStop)
    {
        _isStop = isStop;
    }
}
