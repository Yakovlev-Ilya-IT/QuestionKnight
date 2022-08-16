using UnityEngine;

[RequireComponent(typeof(QuizTextView))]
public abstract class QuizText : MonoBehaviour
{
    protected string _text;

    public virtual void UpdateInformation(string text)
    {
        _text = text;
    }
}
