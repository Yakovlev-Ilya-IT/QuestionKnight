using UnityEngine;
using Zenject;

public class AdventuresFiller : MonoBehaviour
{
    private AdventureSelectionButton[] _adventureSelectionButtons;

    private AdventuresDataProvider _adventuresDataProvider;

    private const int FirstAventureButtonIndex = 0;
    private const int FullPercentageCompletion = 100;

    [Inject]
    private void Initialize(AdventuresDataProvider adventuresDataProvider)
    {
        _adventuresDataProvider = adventuresDataProvider;
    }

    private void Awake()
    {
        _adventureSelectionButtons = GetComponentsInChildren<AdventureSelectionButton>();

        AdventureConfig[] adventureConfigs = _adventuresDataProvider.Load();

        FillAdventureButtons(adventureConfigs);
    }

    private void FillAdventureButtons(AdventureConfig[] adventureConfigs)
    {
        if(adventureConfigs.Length != _adventureSelectionButtons.Length)
        {
            Debug.LogError("The number of adventure settings does not match the number of available buttons");
            return;
        }

        for (int i = 0; i < adventureConfigs.Length; i++)
        {
            if(i == FirstAventureButtonIndex)
                InitializeButton(_adventureSelectionButtons[i], adventureConfigs[i], FullPercentageCompletion);
            else
                InitializeButton(_adventureSelectionButtons[i], adventureConfigs[i], adventureConfigs[i - 1].PercentageCompletion);
        }
    }

    private void InitializeButton(AdventureSelectionButton button, AdventureConfig config, float percentageCompletionPreviousAdventure)
    {
        button.Initialize(config);

        if(config.PercentageCompletionPreviousAdventureToOpen >= percentageCompletionPreviousAdventure)
        {
            button.Lock();
        }
        else
        {
            button.Unlock();
        }
    }
}
