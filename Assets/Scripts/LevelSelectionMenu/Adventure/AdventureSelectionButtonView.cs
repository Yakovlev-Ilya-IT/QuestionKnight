using TMPro;
using UnityEngine;
using DG.Tweening;
using System;

public class AdventureSelectionButtonView : SimpleButtonView
{
    [SerializeField] private TMP_Text _percantageCompletion;

    private const string TitleTemplate = "Путешествие {0}";
    private const string PercantageCompletionTemplate = "{0:f0}%";

    public void Initialize(int adventureNumber, float percantageCompletion)
    {
        Initialize(string.Format(TitleTemplate, adventureNumber));
        _percantageCompletion.text = string.Format(PercantageCompletionTemplate, percantageCompletion);
    }
}
