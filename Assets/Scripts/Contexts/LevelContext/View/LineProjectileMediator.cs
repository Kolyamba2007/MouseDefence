using UnityEngine;

public class LineProjectileMediator : ProjectileMediator<LineProjectileView>
{
    public override void OnRegister()
    {
        base.OnRegister();

        View.CollisionSignal.AddListener(OnCollision);
    }

    public override void OnRemove()
    {
        base.OnRemove();

        View.CollisionSignal.RemoveListener(OnCollision);
    }

    public void OnCollision(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IdentifiableView targetView))
            UnitService.SetDamage(targetView, View.ProjectileData.Damage);

        Destroy(gameObject);
    }
}
