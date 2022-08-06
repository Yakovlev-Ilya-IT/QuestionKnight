using UnityEngine;
using TMPro;

public abstract class QuizTextView : MonoBehaviour
{
    private TMP_Text _text;

    public void Init()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
