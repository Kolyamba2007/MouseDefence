using UnityEngine;

public class ProjectileMediator : ViewMediator<ProjectileView>
{
    [Inject] public IUnitService UnitService { get; set; }

    [Inject] public ClearLevelSignal ClearLevelSignal { get; set; }

    public override void OnRegister()
    {
        ClearLevelSignal.AddListener(DestroyView);
        View.CollisionSignal.AddListener(OnCollision);
    }

    public override void OnRemove()
    {
        ClearLevelSignal.RemoveListener(DestroyView);
        View.CollisionSignal.RemoveListener(OnCollision);
    }

    public void OnCollision(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IdentifiableView targetView))
            UnitService.SetDamage(targetView, View.ProjectileData.Damage);
    }

    private void DestroyView() => Destroy(View.gameObject);
}
