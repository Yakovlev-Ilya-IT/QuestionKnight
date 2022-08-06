public class BackToAdventuresButton : SimpleButton
{
    protected override void Click()
    {
        LevelSelectionEventsHolder.SendBackToAdventuresButtonPressed();
    }
}
