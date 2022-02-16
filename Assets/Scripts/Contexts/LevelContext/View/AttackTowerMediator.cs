using UnityEngine;

public class AttackTowerMediator : TowerMediator<AttackTowerView>
{
    [Inject] public FireSignal FireSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        View.DetectSignal.AddListener(OnEnemyDetect);
    }

    public override void OnRemove()
    {
        base.OnRemove();

        View.DetectSignal.RemoveListener(OnEnemyDetect);
    }

    public void OnEnemyDetect(float distance)
    {
        var td = View.TowerData;
        var projectileData = new ProjectileData(td.Damage, td.ProjectileSpeed, distance, View.FirePoint, View.Line);

        FireSignal.Dispatch(td.ProjectileView, projectileData);
    }
}
