using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class SimpleButton : MonoBehaviour
{
    private Button _button;
    protected bool _isLock;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Click);
    }

    protected abstract void Click();

    public virtual void Lock()
    {
        _isLock = true;

        if(_button == null)
            _button = GetComponent<Button>();
        _button.interactable = false;
    }

    public virtual void Unlock()
    {
        _isLock = false;

        if (_button == null)
            _button = GetComponent<Button>();
        _button.interactable = true;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Click);
    }
}
