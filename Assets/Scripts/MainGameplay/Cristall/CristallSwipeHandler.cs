using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class CristallSwipeHandler : MonoBehaviour, IPause
{
    private float _deadZone => Screen.width/5;
    private Vector3 _swipeDirection;
    private Vector3 _startTapPosition;

    private PauseHandler _pauseHandler;
    private bool _isPaused;

    [Inject]
    private void Construct(PauseHandler pauseHandler)
    {
        _pauseHandler = pauseHandler;
        _pauseHandler.Add(this);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() || _isPaused)
            return;

        _startTapPosition = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Debug.DrawRay(transform.position, new Vector3(Input.mousePosition.x - _startTapPosition.x, Input.mousePosition.y - _startTapPosition.y, 0));
    }

    private void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject() || _isPaused)
            return;

        if (((Vector2)(Input.mousePosition - _startTapPosition)).magnitude > _deadZone)
        {
            _swipeDirection = new Vector3(Input.mousePosition.x - _startTapPosition.x, Input.mousePosition.y - _startTapPosition.y, 0);
            QuizEventHandler.SendCristallSwipeEnded(_swipeDirection.normalized);
        }
    }

    public void SetPause(bool isPaused)
    {
        _isPaused = isPaused;
    }
}
