using UnityEngine;

public class EnemyMediator : ViewMediator<EnemyView>
{
    [Inject] public IUnitService UnitService { get; set; }

    public override void OnRegister()
    {
        View.DetectSignal.AddListener(OnTowerDetect);
    }

    public override void OnRemove()
    {
        View.DetectSignal.RemoveListener(OnTowerDetect);
    }

    public void OnTowerDetect(Collider2D collider)
    {
        if(collider.TryGetComponent(out IdentifiableView targetView))
            UnitService.SetDamage(targetView, View.EnemyData.Damage);
    }
}
