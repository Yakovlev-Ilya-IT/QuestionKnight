using System;

public class LevelSelectionEventsHolder
{
    public static event Action<LevelConfig> LevelSelected;

    public static event Action<QuestionsCategorie> QuestionsCategorieSelected;

    public static event Action<AdventureConfig> AdventureSelected;

    public static event Action BackToAdventuresButtonPressed;

    public static void SendLevelSelected(LevelConfig levelConfig)
    {
        LevelSelected?.Invoke(levelConfig);
    }

    public static void SendQuestionsCategorieSelected(QuestionsCategorie questionsCategorie)
    {
        QuestionsCategorieSelected?.Invoke(questionsCategorie);
    }

    public static void SendAdventureSelected(AdventureConfig adventureConfig)
    {
        AdventureSelected?.Invoke(adventureConfig);
    }

    public static void SendBackToAdventuresButtonPressed()
    {
        BackToAdventuresButtonPressed?.Invoke();
    }

}
