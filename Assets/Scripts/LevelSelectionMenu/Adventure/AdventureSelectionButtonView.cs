using TMPro;
using UnityEngine;
using DG.Tweening;
using System;

public class AdventureSelectionButtonView : SimpleButtonView
{
    [SerializeField] private TMP_Text _percantageCompletion;
    [SerializeField] private RectTransform _button;

    private const string TitleTemplate = "Путешествие {0}";
    private const string PercantageCompletionTemplate = "{0:f0}%";

    private Vector2 _showPosition => _button.anchoredPosition;
    private Vector2 HidePosition => _showPosition + Vector2.right * 50;

    public void Initialize(int adventureNumber, float percantageCompletion)
    {
        Initialize(string.Format(TitleTemplate, adventureNumber));
        _button = GetComponent<RectTransform>();
        _percantageCompletion.text = string.Format(PercantageCompletionTemplate, percantageCompletion);
    }
}
