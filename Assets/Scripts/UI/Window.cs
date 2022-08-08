using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Window : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void Open()
    {
        _canvasGroup.OpenWindow();
    }

    public virtual void Close()
    {
        _canvasGroup.CloseWindow();
    }
}
