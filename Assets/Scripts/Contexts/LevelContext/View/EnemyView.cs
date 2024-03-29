using strange.extensions.signal.impl;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public partial class EnemyView : IdentifiableView
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _attackAnimName;

    [SerializeField] private SortingGroup _sortingGroup;

    private RaycastHit2D[] m_Result = new RaycastHit2D[1];
    private int hit;
    private LayerMask _mask;

    public EnemyData EnemyData { get; private set; }

    public Signal<Collider2D> DetectSignal { get; } = new Signal<Collider2D>();

    public override void Init()
    {
        _sortingGroup.sortingLayerName = $"Line{Line}";
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
            hit = Physics2D.RaycastNonAlloc(transform.position, Vector3.left, m_Result, EnemyData.AttackDistance, _mask);

            if (hit != 0)
            {
                if (!_animator.GetBool(_attackAnimName))
                    _animator.SetBool(_attackAnimName, true);
            }
            else
            {
                if(_animator.GetBool(_attackAnimName))
                    _animator.SetBool(_attackAnimName, false);

                transform.position += Vector3.left * EnemyData.MovementSpeed * Time.deltaTime;
            }

            yield return null;
        }
    }

    private void HandleAnimEvent()
    {
        if(hit != 0)
            DetectSignal.Dispatch(m_Result[0].collider);
    }
}
