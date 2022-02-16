using strange.extensions.signal.impl;
using UnityEngine;

public class LineProjectileView : ProjectileView
{
    private int _layerMask;

    public Signal<Collision2D> CollisionSignal { get; } = new Signal<Collision2D>();

    public override void Init() 
    {
        GetComponent<SpriteRenderer>().sortingLayerName = $"Line{ProjectileData.LineNumber}";
        _layerMask = LayerMask.NameToLayer($"Enemy{ProjectileData.LineNumber}");
    } 

    private void Update() =>
        transform.position += Vector3.right * 4f * Time.deltaTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _layerMask)
        {
            CollisionSignal.Dispatch(collision);
            Destroy(gameObject);
        }
    }
}