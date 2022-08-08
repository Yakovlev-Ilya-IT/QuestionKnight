using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public abstract class WindowView : MonoBehaviour
{
    [SerializeField] private Image _anticlicker;
    [SerializeField] private RectTransform _mainContainer;
    [SerializeField] CanvasGroup _mainContainerCanvasGroup;

    [SerializeField] private float _animationTime = 1f;

    private const float StartFade = 0f;
    private const float EndFade = 1f;

    [SerializeField] private float _mainContainerStartScale = 0.3f;
    [SerializeField] private float _mainContainerEndScale = 1f;

    public virtual void Open()
    {
        _anticlicker.DOFade(EndFade, _animationTime).From(StartFade);
        _mainContainerCanvasGroup.DOFade(EndFade, _animationTime).From(StartFade);
        _mainContainer.DOScale(_mainContainerEndScale, _animationTime).From(_mainContainerStartScale);
    }

    public virtual void Close()
    {
        _anticlicker.DOFade(StartFade, _animationTime).From(EndFade);
        _mainContainerCanvasGroup.DOFade(StartFade, _animationTime).From(EndFade);
        _mainContainer.DOScale(_mainContainerStartScale, _animationTime).From(_mainContainerEndScale);
    }
}
