using strange.extensions.signal.impl;
using System.Collections;
using UnityEngine;

public partial class TowerView : IdentifiableView
{
    [SerializeField] private Transform _firePoint;

    private RaycastHit2D[] m_Result = new RaycastHit2D[1];
    private LayerMask _mask;

    public int Line { get; private set; }
    public TowerData TowerData { get; private set; }
    public Vector2 FirePoint => _firePoint.position;

    public Signal<Collider2D> DetectSignal { get; } = new Signal<Collider2D>();

    protected override void Start()
    {
        base.Start();

        StartCoroutine(EnemyDetect());
    }

    public override void Init()
    {
        _mask = LayerMask.GetMask($"Enemy{Line}");
        GetComponent<SpriteRenderer>().sortingLayerName = $"Line{Line}";
    }

    public override void SetData(IUnitData towerData, UnitViewData viewData)
    {
        TowerData = (TowerData)towerData;
        ID = viewData.ID;
        Line = viewData.Line;
    }

    private IEnumerator EnemyDetect()
    {
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
