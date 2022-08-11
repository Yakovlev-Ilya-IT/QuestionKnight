using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TypeWriter: MonoBehaviour
{
    [SerializeField] private float _delayBtwNewChar = 0.05f;
    private TMP_Text _textField;

    private void Awake()
    {
        _textField = GetComponent<TMP_Text>();
    }

    public void Write(string text)
    {
        StopAllCoroutines();
        _textField.text = "";
        StartCoroutine(Type(text));
    }

    IEnumerator Type(string text)
    {
        foreach (char letter in text)
        {
            _textField.text += letter;
            yield return new WaitForSeconds(_delayBtwNewChar);
        }
    }
}
