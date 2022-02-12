using UnityEngine;

public class TowerMediator : ViewMediator<TowerView>
{
    [Inject] public IUnitService UnitService { get; set; }

    [Inject] public FireSignal FireSignal { get; set; }

    [Inject] public ClearLevelSignal ClearLevelSignal { get; set; }

    public override void OnRegister()
    {
        ClearLevelSignal.AddListener(DestroyUnit);
        View.DetectSignal.AddListener(OnEnemyDetect);
    }

    public override void OnRemove()
    {
        ClearLevelSignal.RemoveListener(DestroyUnit);
        View.DetectSignal.RemoveListener(OnEnemyDetect);
    }

    public void OnEnemyDetect(Collider2D collider)
    {
        var td = View.TowerData;
        var projectileData = new ProjectileData(View.Line, View.FirePoint, td.Damage);

        FireSignal.Dispatch(td.ProjectileView, projectileData);
    }

    private void DestroyUnit() => UnitService.Remove(View);
}
