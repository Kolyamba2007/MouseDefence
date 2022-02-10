using UnityEngine;

public class TowerMediator : ViewMediator<TowerView>
{
    [Inject] public FireSignal FireSignal { get; set; }

    public override void OnRegister()
    {
        View.DetectSignal.AddListener(OnEnemyDetect);
    }

    public override void OnRemove()
    {
        View.DetectSignal.RemoveListener(OnEnemyDetect);
    }

    public void OnEnemyDetect(Collider2D collider)
    {
        var td = View.TowerData;
        var projectileData = new ProjectileData(View.Line, View.FirePoint, td.Damage);

        FireSignal.Dispatch(td.ProjectileView, projectileData);
    }
}
