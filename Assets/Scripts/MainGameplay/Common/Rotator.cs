using UnityEngine;
using Zenject;

public class Rotator : MonoBehaviour, IPause
{
    [SerializeField] protected float _startRotateSpeed;
    protected float _rotateSpeed;

    private Vector3 _directionOfAxisRotation;

    private PauseHandler _pauseHandler;
    private bool _isPaused;

    [Inject]
    private void Construct(PauseHandler pauseHandler)
    {
        _pauseHandler = pauseHandler;
        _pauseHandler.Add(this);
    }

    public void Initialize(Vector3 angle)
    {
        _rotateSpeed = _startRotateSpeed;

        _directionOfAxisRotation = new Vector3(Random.value, Random.value, Random.value);
        _directionOfAxisRotation.Normalize();

        transform.eulerAngles = angle;
    }

    protected void Update()
    {
        if (_isPaused)
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

    public void SetPause(bool isPaused)
    {
        _isPaused = isPaused;
    }
}
