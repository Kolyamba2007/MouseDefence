using UnityEngine;

public class EnemyMediator : ViewMediator<EnemyView>
{
    [Inject] public IUnitService UnitService { get; set; }

    [Inject] public ClearLevelSignal ClearLevelSignal { get; set; }

    public override void OnRegister()
    {
        ClearLevelSignal.AddListener(DestroyUnit);
        View.DetectSignal.AddListener(OnTowerDetect);
    }

    public override void OnRemove()
    {
        ClearLevelSignal.RemoveListener(DestroyUnit);
        View.DetectSignal.RemoveListener(OnTowerDetect);
    }

    public void OnTowerDetect(Collider2D collider)
    {
        if(collider.TryGetComponent(out IdentifiableView targetView))
            UnitService.SetDamage(targetView, View.EnemyData.Damage);
    }

    private void DestroyUnit() => UnitService.Remove(View);
}
