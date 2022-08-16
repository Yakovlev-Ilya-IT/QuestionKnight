using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Image))]
public class AnswerArrow : MonoBehaviour
{
    private Image _arrow;

    [SerializeField] private AnswerLocationSide _locationSide;
    [SerializeField] private Color _selectColor;
    [SerializeField] private Color _unselectColor;

    [SerializeField] private float _fadeSpeed = 2;
    private float _currentFade = 0;

    private Vector3 _startClickPosition;

    private CristallSwipeHandler _cristallSwipeHandler;
    private IInput _input;

    private const string Fade = "_Fade";
    private const float MaxFade = 1;
    private const float MinFade = 0;

    [Inject]
    private void Contruct(CristallSwipeHandler cristallSwipeHandler, IInput input)
    {
        _cristallSwipeHandler = cristallSwipeHandler;
        _input = input;
    }

    private void Awake()
    {
        _arrow = GetComponent<Image>();
        _arrow.material.SetFloat(Fade, MinFade);
    }

    private void OnEnable()
    {
        _cristallSwipeHandler.ClickedCristall += OnClickedCristall;
        _cristallSwipeHandler.Drag += OnDrag;
        _input.ClickUp += OnClickUp;
    }

    private void OnClickedCristall(Vector3 clickPosition)
    {
        _startClickPosition = clickPosition;
        StopAllCoroutines();
        StartCoroutine(Appear());
    }

    private void OnDrag(Vector3 inputPosition, bool isLeftDeadZone)
    {
        if (CheckSelection(inputPosition) && isLeftDeadZone)
            _arrow.color = _selectColor;
        else
            _arrow.color = _unselectColor;
    }

    private void OnClickUp(Vector3 clickPosition)
    {
        _arrow.color = _unselectColor;
        StopAllCoroutines();
        StartCoroutine(Disappear());
    }

    private IEnumerator Appear()
    {
        while(_currentFade <= MaxFade)
        {
            _currentFade += Time.deltaTime * _fadeSpeed;
            _arrow.material.SetFloat(Fade, _currentFade);
            yield return null;
        }
    }
    private IEnumerator Disappear()
    {
        while (_currentFade >= MinFade)
        {
            _currentFade -= Time.deltaTime * _fadeSpeed;
            _arrow.material.SetFloat(Fade, _currentFade);
            yield return null;
        }
    }

    private bool CheckSelection(Vector3 inputPosition)
    {
        return SideDetector.GetLocation((inputPosition - _startClickPosition).normalized) == _locationSide;
    }

    private void OnDisable()
    {
        _cristallSwipeHandler.ClickedCristall -= OnClickedCristall;
        _cristallSwipeHandler.Drag -= OnDrag;
        _input.ClickUp -= OnClickUp;
    }

}
