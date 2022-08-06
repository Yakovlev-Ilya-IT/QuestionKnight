using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenuPanelSwitcher : MonoBehaviour
{
    [SerializeField] private Transform _adventureSelectionPanel;
    [SerializeField] private Transform _levelSelectionPanel;

    private void OnEnable()
    {
        LevelSelectionEventsHolder.AdventureSelected += OnAdventureSelected;
        LevelSelectionEventsHolder.BackToAdventuresButtonPressed += OnBackToAdventuresButtonPressed;
    }

    private void OnAdventureSelected(AdventureConfig config)
    {
        _adventureSelectionPanel.gameObject.SetActive(false);
        _levelSelectionPanel.gameObject.SetActive(true);
    }

    private void OnBackToAdventuresButtonPressed()
    {
        _adventureSelectionPanel.gameObject.SetActive(true);
        _levelSelectionPanel.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        LevelSelectionEventsHolder.AdventureSelected -= OnAdventureSelected;
        LevelSelectionEventsHolder.BackToAdventuresButtonPressed -= OnBackToAdventuresButtonPressed;
    }
}
