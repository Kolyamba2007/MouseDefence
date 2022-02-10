using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class ProjectileView : View
{
    public ProjectileData ProjectileData { get; private set; }

    public Signal<Collision2D> CollisionSignal { get; } = new Signal<Collision2D>();

    public void SetData(ProjectileData projectileData)
    {
        ProjectileData = projectileData;

        GetComponent<SpriteRenderer>().sortingLayerName = $"Line{ProjectileData.LineNumber}";
    }

    private void Update()
    {
        transform.position += Vector3.right * 4f * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer($"Enemy{ProjectileData.LineNumber}"))
        {
            CollisionSignal.Dispatch(collision);
            Destroy(gameObject);
        }
    }
}
