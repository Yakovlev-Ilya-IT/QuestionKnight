using UnityEngine;
using Zenject;

public class AdventureButtonsFiller : MonoBehaviour
{
    private AdventuresDataProvider _adventuresDataProvider;

    private const int FirstAventureButtonIndex = 0;
    private const int FullPercentageCompletion = 100;

    [Inject]
    private void Construct(AdventuresDataProvider adventuresDataProvider)
    {
        _adventuresDataProvider = adventuresDataProvider;
    }

    public void Fill(AdventureSelectionButton[] adventureSelectionButtons)
    {
        AdventureConfig[] adventureConfigs = _adventuresDataProvider.Load();

        if (adventureConfigs.Length != adventureSelectionButtons.Length)
        {
            Debug.LogError("The number of adventure settings does not match the number of available buttons");
            return;
        }

        for (int i = 0; i < adventureConfigs.Length; i++)
        {
            if(i == FirstAventureButtonIndex)
                InitializeButton(adventureSelectionButtons[i], adventureConfigs[i], FullPercentageCompletion);
            else
                InitializeButton(adventureSelectionButtons[i], adventureConfigs[i], adventureConfigs[i - 1].PercentageCompletion);
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
