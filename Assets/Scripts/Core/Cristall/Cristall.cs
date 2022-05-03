using UnityEngine;

[RequireComponent(typeof(CristallRotator), typeof(CristallSwipeHandler))]
public class Cristall : MonoBehaviour
{
    private CristallRotator _cristallRotator;
    private CristallSwipeHandler _cristallSwipeHandler;

    private void Awake()
    {
        _cristallRotator = GetComponent<CristallRotator>();
        _cristallSwipeHandler = GetComponent<CristallSwipeHandler>();
        QuizEventHandler.CristallSwipeEnded += OnSwipeEnded;
    }

    public void Init()
    {
        _cristallRotator.Init(new Vector3(Random.value, Random.value, Random.value));
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
