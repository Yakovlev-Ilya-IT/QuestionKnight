using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelectionButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private SceneID _categorie;

    public event Action<LevelConfig> LevelSelected;

    public void OnPointerClick(PointerEventData eventData)
    {
        LevelSelectionEventsHolder.SendLevelSelected(_levelConfig, _categorie);
    }
}
