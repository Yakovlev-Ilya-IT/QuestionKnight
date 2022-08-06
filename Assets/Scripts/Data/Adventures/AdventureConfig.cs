using UnityEngine;

[CreateAssetMenu(fileName = "AdventureConfig", menuName = "Game/AdventureConfig")]
public class AdventureConfig : ScriptableObject, ISaveable
{
    [SerializeField] private int _adventureNumber;
    [SerializeField] private QuestionsCategorie[] _questionsCategories;
    [SerializeField] private float _percentageCompletionPreviousAdventureToOpen = 50;

    private AdventureSaveData _saveData = new AdventureSaveData();

    public int AdventureNumber => _adventureNumber;
    public QuestionsCategorie[] QuestionsCategories => _questionsCategories;
    public float PercentageCompletionPreviousAdventureToOpen => _percentageCompletionPreviousAdventureToOpen;
    public object SaveableObject => _saveData;

    public int CompleteLevels
    {
        get => _saveData.CompleteLevels;
        set
        {
            if(value >= 0)
                _saveData.CompleteLevels = value;
        }
    }

    public int LevelsCount
    {
        get => _saveData.LevelsCount;
        set
        {
            if(value >= _saveData.MinimumLevelsCount)
                _saveData.LevelsCount = value;
        }
    }

    public float PercentageCompletion => (float)CompleteLevels * 100 / LevelsCount;

    public string GetFileName()
    {
        return $"Adventure{_adventureNumber}.json";
    }
}
