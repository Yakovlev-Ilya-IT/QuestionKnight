using UnityEngine;

public class EnemyAttackState : BaseLevelCycleState
{
    public EnemyAttackState(Player player, LevelScenario scenario, IStationStateSwitcher stateSwitcher) : base(player, scenario, stateSwitcher)
    {
    }

    public override void Launch()
    {
        _player.ProtectionStageIsOver += OnProtectionStageIsOver;
        _player.Died += OnDied;
        _scenario.CurrentEnemy.DealDamage();
    }

    private void OnProtectionStageIsOver()
    {
        _stateSwitcher.SwitchState<WaitingForAnswerState>();
    }

    private void OnDied()
    {
        Debug.Log("LOOSE");
    }

    public override void Stop()
    {
        _player.ProtectionStageIsOver -= OnProtectionStageIsOver;
        _player.Died -= OnDied;
    }

    public override void EnemyAttack() {}

    public override void PlayerAttack() {}
}
