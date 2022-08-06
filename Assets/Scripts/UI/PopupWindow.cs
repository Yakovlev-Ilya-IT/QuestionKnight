using UnityEngine;

public class PopupWindow : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public virtual void Open()
    {
        //gameObject.SetActive(true);
        _canvasGroup.OpenWindow();
    }

    public virtual void Close()
    {
        _canvasGroup.CloseWindow();
    }
}
