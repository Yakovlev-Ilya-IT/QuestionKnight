using System.Collections;
using UnityEngine;
using TMPro;

public class TypeWriter: MonoBehaviour
{
    [SerializeField] private float _delayBtwNewChar;
    [SerializeField] private TMP_Text _placement;

    public void Write(string text)
    {
        StopAllCoroutines();
        _placement.text = "";
        StartCoroutine(Type(text));
    }

    IEnumerator Type(string text)
    {
        foreach (char letter in text)
        {
            _placement.text += letter;
            yield return new WaitForSeconds(_delayBtwNewChar);
        }
    }
}
