using System.Collections.Generic;
using UnityEngine;

public class HeavyProjectileMediator : ProjectileMediator<HeavyProjectileView>
{
    public override void OnRegister()
    {
        base.OnRegister();

        ClearLevelSignal.AddListener(View.StopMove);
        View.DetectEnemiesSignal.AddListener(OnEnemyDetect);
    }

    public override void OnRemove()
    {
        base.OnRemove();

        View.StopMove();
        ClearLevelSignal.RemoveListener(View.StopMove);
        View.DetectEnemiesSignal.RemoveListener(OnEnemyDetect);
    }

    public void OnEnemyDetect(Collider2D[] enemies)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.TryGetComponent(out IdentifiableView targetView))
                UnitService.SetDamage(targetView, View.ProjectileData.Damage);
        }
        Destroy(gameObject);
    }
}
