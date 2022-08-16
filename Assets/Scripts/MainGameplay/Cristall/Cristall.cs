using UnityEngine;
using Zenject;

public class Cristall : MonoBehaviour, IPause
{
    [SerializeField] private CristallRotator _cristallRotator;
    [SerializeField] private CristallView _view;

    private PauseHandler _pauseHandler;
    private CristallSwipeHandler _cristallSwipeHandler;

    private void OnEnable()
    {
        _cristallSwipeHandler.CristallSwipeEnded += OnSwipeEnded;
    }

    [Inject]
    private void Construct(PauseHandler pauseHandler, CristallSwipeHandler cristallSwipeHandler)
    {
        _pauseHandler = pauseHandler;
        _cristallSwipeHandler = cristallSwipeHandler;
        _pauseHandler.Add(this);
        _cristallRotator.Initialize(new Vector3(Random.value, Random.value, Random.value));
        _view.Initialize();
    }

    private void OnSwipeEnded(Vector3 direction)
    {
        _cristallRotator.SetRotationDirection(direction);
        _cristallRotator.AccelerateRotation();
    }

    private void OnDisable()
    {
        _cristallSwipeHandler.CristallSwipeEnded -= OnSwipeEnded;
    }

    public void SetPause(bool isPaused)
    {
        _cristallRotator.SetStop(isPaused);
        _view.SetPause(isPaused);
    }
}
