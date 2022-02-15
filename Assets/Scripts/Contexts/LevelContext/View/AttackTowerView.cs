using strange.extensions.signal.impl;
using System.Collections;
using UnityEngine;

public class AttackTowerView : TowerView
{
    [SerializeField] private Transform _firePoint;

    private RaycastHit2D[] m_Result = new RaycastHit2D[1];

    public Vector2 FirePoint => _firePoint.position;

    public Signal<Collider2D> DetectSignal { get; } = new Signal<Collider2D>();

    protected override void Start()
    {
        base.Start();

        StartCoroutine(EnemyDetect());
    }

    private IEnumerator EnemyDetect()
    {
        var _mask = LayerMask.GetMask($"Enemy{Line}");

        while (true)
        {
            int hit = Physics2D.RaycastNonAlloc(transform.position, Vector3.right, m_Result, TowerData.AttackDistance, _mask);

            if (hit != 0)
            {
                DetectSignal.Dispatch(m_Result[0].collider);

                yield return new WaitForSeconds(TowerData.AttackSpeed);
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
