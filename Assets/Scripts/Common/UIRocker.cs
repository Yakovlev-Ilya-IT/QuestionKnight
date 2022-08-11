using UnityEngine;
using DG.Tweening;

public class UIRocker : MonoBehaviour
{
    private RectTransform _object;
    [SerializeField] private float _oneCycleDuration = 1;
    [SerializeField] private float _amplitude = 1;
    [SerializeField] private AnimationCurve _curve;
    
    private void Awake()
    {
        _object = GetComponent<RectTransform>();
        _object.DOAnchorPosY(_object.anchoredPosition.y + _amplitude, _oneCycleDuration)
            .From(_object.anchoredPosition - new Vector2(0, _amplitude))
            .SetEase(_curve)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
