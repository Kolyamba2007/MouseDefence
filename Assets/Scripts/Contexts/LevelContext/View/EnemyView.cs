using strange.extensions.signal.impl;
using System.Collections;
using UnityEngine;

public partial class EnemyView : IdentifiableView
{
    private RaycastHit2D[] m_Result = new RaycastHit2D[1];
    private LayerMask _mask;

    public EnemyData EnemyData { get; private set; }

    public Signal<Collider2D> DetectSignal { get; } = new Signal<Collider2D>();

    public override void Init()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = $"Line{Line}";
        gameObject.layer = LayerMask.NameToLayer($"Enemy{Line}");
        _mask = LayerMask.GetMask("Tower");

        StartCoroutine(TowerDetect());
    }

    public override void SetData(IUnitData enemyData, UnitViewData viewData)
    {
        EnemyData = (EnemyData)enemyData;

        ID = viewData.ID;
        Line = viewData.Line;
    }

    private IEnumerator TowerDetect()
    {
        while (true)
        {
            int hit = Physics2D.RaycastNonAlloc(transform.position, Vector3.left, m_Result, EnemyData.AttackDistance, _mask);

            if (hit != 0)
            {
                DetectSignal.Dispatch(m_Result[0].collider);

                yield return new WaitForSeconds(EnemyData.AttackSpeed);
            }
            else
                transform.position += Vector3.left * EnemyData.MovementSpeed * Time.deltaTime;

            yield return null;
        }
    }
}
