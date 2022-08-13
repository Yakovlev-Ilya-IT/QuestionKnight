using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class CristallSwipeHandler : MonoBehaviour, IPause
{
    private float DeadZone => Screen.width/5;
    private Vector3 _swipeDirection;
    private Vector3 _startTapPosition;

    private PauseHandler _pauseHandler;
    private bool _isPaused;

    private bool _isSwiping;

    private IInput _input;

    [Inject]
    private void Construct(PauseHandler pauseHandler, IInput input)
    {
        _pauseHandler = pauseHandler;
        _pauseHandler.Add(this);
        _input = input;
    }

    private void OnEnable()
    {
        _input.ClickDown += OnClickDown;
        _input.ClickUp += OnClickUp;
        _input.Drag += OnDrag;
    }

    private void OnClickDown(Vector3 inputPosition)
    {
        if (CheckClickDownPossibility())
            return;

        Ray ray = Camera.main.ScreenPointToRay(inputPosition);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.transform.TryGetComponent(out Cristall cristall))
            {
                _startTapPosition = inputPosition;
                _isSwiping = true;
            }
        }
    }

    private void OnDrag(Vector3 inputPosition)
    {
        if (_isSwiping)
        {
            Debug.DrawRay(transform.position, new Vector3(inputPosition.x - _startTapPosition.x, inputPosition.y - _startTapPosition.y, 0));
        }
    }

    private void OnClickUp(Vector3 inputPosition)
    {
        if (CheckClickUpPossibility())
            return;

        _isSwiping = false;

        if (((Vector2)(inputPosition - _startTapPosition)).magnitude > DeadZone)
        {
            _swipeDirection = new Vector3(inputPosition.x - _startTapPosition.x, inputPosition.y - _startTapPosition.y, 0);
            QuizEventHandler.SendCristallSwipeEnded(_swipeDirection.normalized);
        }
    }

    private bool CheckClickDownPossibility()
    {
        return EventSystem.current.IsPointerOverGameObject() || _isPaused;
    }

    private bool CheckClickUpPossibility()
    {
        return EventSystem.current.IsPointerOverGameObject() || _isPaused || !_isSwiping;
    }

    public void SetPause(bool isPaused)
    {
        _isPaused = isPaused;
    }

    private void OnDisable()
    {
        _input.ClickDown -= OnClickDown;
        _input.ClickUp -= OnClickUp;
        _input.Drag -= OnDrag;
    }
}
