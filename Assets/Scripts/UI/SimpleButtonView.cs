using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public abstract class SimpleButtonView : MonoBehaviour
{
    [SerializeField] protected TMP_Text _text;
    [SerializeField] protected Color _backgroundStandartColor;
    [SerializeField] protected Color _backgroundLockColor;

    protected Image _background;

    protected void Initialize(string text)
    {
        _text.text = text;
        _background = GetComponent<Image>();
        _background.color = _backgroundStandartColor;
    }

    public virtual void Lock()
    {
        _background.color = _backgroundLockColor;
    }
    public virtual void Unlock()
    {
        _background.color = _backgroundStandartColor;
    }
}
