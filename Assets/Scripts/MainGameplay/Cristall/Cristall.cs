using UnityEngine;
using Zenject;

public class Cristall : MonoBehaviour
{
    [SerializeField] private CristallRotator _cristallRotator;
    [SerializeField] private CristallSwipeHandler _cristallSwipeHandler;

    private void OnEnable()
    {
        QuizEventHandler.CristallSwipeEnded += OnSwipeEnded;
    }

    [Inject]
    public void Init()
    {
        _cristallRotator.Initialize(new Vector3(Random.value, Random.value, Random.value));
    }

    private void OnSwipeEnded(Vector3 direction)
    {
        _cristallRotator.SetRotationDirection(direction);
        _cristallRotator.AccelerateRotation();
    }

    private void OnDisable()
    {
        QuizEventHandler.CristallSwipeEnded -= OnSwipeEnded;
    }

}
