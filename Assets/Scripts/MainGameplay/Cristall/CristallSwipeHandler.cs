using System;
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

    public event Action<Vector3> ClickedCristall;
    public event Action<Vector3, bool> Drag;
    public event Action<Vector3> CristallSwipeEnded;

    private Camera _camera;

    [Inject]
    private void Construct(PauseHandler pauseHandler, IInput input)
    {
        _pauseHandler = pauseHandler;
        _pauseHandler.Add(this);
        _camera = Camera.main;
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

        Ray ray = _camera.ScreenPointToRay(inputPosition);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.transform.TryGetComponent(out Cristall cristall))
            {
                _startTapPosition = inputPosition;
                ClickedCristall?.Invoke(inputPosition);
                _isSwiping = true;
            }
        }
    }

    private void OnDrag(Vector3 inputPosition)
    {
        if (_isSwiping && CheckLeftDeadZone(inputPosition))
            Drag?.Invoke(inputPosition, true);
        else
            Drag?.Invoke(Vector3.zero, false);
    }

    private void OnClickUp(Vector3 inputPosition)
    {
        if (CheckClickUpPossibility())
            return;

        _isSwiping = false;

        if (CheckLeftDeadZone(inputPosition))
        {
            _swipeDirection = new Vector3(inputPosition.x - _startTapPosition.x, inputPosition.y - _startTapPosition.y, 0);
            CristallSwipeEnded?.Invoke(_swipeDirection.normalized);
        }
    }

    private bool CheckLeftDeadZone(Vector3 inputPosition)
    {
        return ((Vector2)(inputPosition - _startTapPosition)).magnitude > DeadZone;
    }

    private bool CheckClickDownPossibility()
    {
        return EventSystem.current.IsPointerOverGameObject() || _isPaused;
    }

    private bool CheckClickUpPossibility()
    {
        return _isPaused || !_isSwiping;
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
