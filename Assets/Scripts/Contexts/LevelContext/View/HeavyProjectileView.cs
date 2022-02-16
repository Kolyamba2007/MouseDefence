using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyProjectileView : ProjectileView
{
    private AnimationCurve _curve = new AnimationCurve();
    private Coroutine _coroutine;
    private int _layerMask;

    private List<Collider2D> _enemies = new List<Collider2D>();

    public Signal<Collider2D[]> DetectEnemiesSignal { get; } = new Signal<Collider2D[]>();

    public override void Init()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = $"Line{ProjectileData.LineNumber}";
        _layerMask = LayerMask.NameToLayer($"Enemy{ProjectileData.LineNumber}");

        _curve.AddKey(new Keyframe(0, 0, 0, 1.5f, 0, .4f));
        _curve.AddKey(new Keyframe(ProjectileData.FireDistance, 0, -1.3f, 0, .4f, 0));

        _coroutine = StartCoroutine(Move(ProjectileData.FireDistance, ProjectileData.Speed));
    }

    private IEnumerator Move(float distance, float speed)
    {
        Vector2 startPos = transform.position;
        float t = 0;

        while (t < distance)
        {
            t = Mathf.Clamp(t + Time.deltaTime * speed, 0, distance);
            transform.position = startPos + new Vector2(t, _curve.Evaluate(t));

            yield return null;
        }

        DetectEnemiesSignal.Dispatch(_enemies.ToArray());
    }

    public void StopMove() => 
        StopCoroutine(_coroutine);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _layerMask)
            DetectEnemiesSignal.Dispatch(_enemies.ToArray());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _layerMask)
            _enemies.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _layerMask)
            _enemies.Remove(collision);
    }
}
