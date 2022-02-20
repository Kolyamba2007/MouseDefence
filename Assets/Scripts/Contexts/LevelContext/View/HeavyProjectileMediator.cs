using UnityEngine;

public class HeavyProjectileMediator : ProjectileMediator<HeavyProjectileView>
{
    public override void OnRegister()
    {
        base.OnRegister();

        ClearLevelSignal.AddListener(View.StopMove);
        View.CollisionSignal.AddListener(OnCollision);
    }

    public override void OnRemove()
    {
        base.OnRemove();

        View.StopMove();
        ClearLevelSignal.RemoveListener(View.StopMove);
        View.CollisionSignal.RemoveListener(OnCollision);
    }

    public void OnCollision(Collider2D[] enemies)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.TryGetComponent(out IdentifiableView targetView))
                UnitService.SetDamage(targetView, View.ProjectileData.Damage);
        }
        Destroy(gameObject);
    }
}
