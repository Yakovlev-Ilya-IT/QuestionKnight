using UnityEngine;
using Zenject;

public class Question: QuizText
{
    public new void Init()
    {
        base.Init();
    }

    public new void UpdateInformation(string text)
    {
        //проверь параметры
        base.UpdateInformation(text);
    }
}
