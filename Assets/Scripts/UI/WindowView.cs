using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public abstract class WindowView : MonoBehaviour
{
    [SerializeField] private Image _anticlicker;
    [SerializeField] private RectTransform _mainContainer;
    [SerializeField] CanvasGroup _mainContainerCanvasGroup;

    [SerializeField] private float _animationTime = 1f;

    private const float StartFade = 0f;
    private const float EndFade = 1f;

    [SerializeField] private float _endAnticlickerFade = 1f;

    [SerializeField] private float _mainContainerStartScale = 0.3f;
    [SerializeField] private float _mainContainerEndScale = 1f;

    public virtual void Open(TweenCallback callback = null)
    {
        _anticlicker.DOFade(_endAnticlickerFade, _animationTime).From(StartFade);
        _mainContainerCanvasGroup.DOFade(EndFade, _animationTime).From(StartFade).OnComplete(callback);
        _mainContainer.DOScale(_mainContainerEndScale, _animationTime).From(_mainContainerStartScale);
    }

    public virtual void Close(TweenCallback callback = null)
    {
        _anticlicker.DOFade(StartFade, _animationTime).From(_endAnticlickerFade);
        _mainContainerCanvasGroup.DOFade(StartFade, _animationTime).From(EndFade).OnComplete(callback);
        _mainContainer.DOScale(_mainContainerStartScale, _animationTime).From(_mainContainerEndScale);
    }
}
