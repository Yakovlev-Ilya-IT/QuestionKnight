public class Enemy : Character
{
    private float _timeToAnswer;

    private LevelScenario _scenario;

    public float TimeToAnswer => _timeToAnswer;

    public void Initialize(int maxHealth, int attackDamage, float timeToAnswer, IDamageable target, LevelScenario scenario)
    {
        Initialize(maxHealth, attackDamage, target);

        _timeToAnswer = timeToAnswer;
        _scenario = scenario;
    }

    protected override void OnDeathAnimationFinished()
    {
        _scenario.Recycle();
        base.OnDeathAnimationFinished();
    }
}
