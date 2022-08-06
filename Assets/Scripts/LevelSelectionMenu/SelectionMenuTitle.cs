using System;
using UnityEngine;

[RequireComponent(typeof(TypeWriter))]
public class SelectionMenuTitle : MonoBehaviour
{
    [SerializeField] string _levelSelectionText;
    [SerializeField] string _adventureSelectionText;
    private TypeWriter _typeWriter;

    private void Awake()
    {
        _typeWriter = GetComponent<TypeWriter>();
    }

    private void OnEnable()
    {
        LevelSelectionEventsHolder.AdventureSelected += OnAdventureSelected;
        LevelSelectionEventsHolder.BackToAdventuresButtonPressed += OnBackToAdventuresButtonPressed;
    }

    private void OnAdventureSelected(AdventureConfig config)
    {
        _typeWriter.Write(_levelSelectionText);
    }

    public void OnBackToAdventuresButtonPressed()
    {
        _typeWriter.Write(_adventureSelectionText);
    }

    private void OnDisable()
    {
        LevelSelectionEventsHolder.AdventureSelected -= OnAdventureSelected;
        LevelSelectionEventsHolder.BackToAdventuresButtonPressed -= OnBackToAdventuresButtonPressed;
    }
}
