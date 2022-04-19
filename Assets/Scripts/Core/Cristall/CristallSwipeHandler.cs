using UnityEngine;

public class CristallSwipeHandler : MonoBehaviour
{
    private float _deadZone => Screen.width/5;
    private Vector3 _swipeDirection;
    private Vector3 _startTapPosition;

    private void OnMouseDown()
    {
        _startTapPosition = Input.mousePosition;
        QuizEventHandler.SendCristallSwipeBegun();
    }

    private void OnMouseDrag()
    {
        Debug.DrawRay(transform.position, new Vector3(Input.mousePosition.x - _startTapPosition.x, Input.mousePosition.y - _startTapPosition.y, 0));
    }

    private void OnMouseUp()
    {
        if(((Vector2)(Input.mousePosition - _startTapPosition)).magnitude > _deadZone)
        {
            _swipeDirection = new Vector3(Input.mousePosition.x - _startTapPosition.x, Input.mousePosition.y - _startTapPosition.y, 0);
            QuizEventHandler.SendCristallSwipeEnded(_swipeDirection.normalized);
        }
    }
}
