using strange.extensions.signal.impl;
using UnityEngine;

public class LineProjectileView : ProjectileView
{
    public Signal<Collision2D> CollisionSignal { get; } = new Signal<Collision2D>();

    private void Update() =>
        transform.position += Vector3.right * 4f * Time.deltaTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer($"Enemy{ProjectileData.LineNumber}"))
        {
            CollisionSignal.Dispatch(collision);
            Destroy(gameObject);
        }
    }
}