using strange.extensions.signal.impl;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public partial class EnemyView : IdentifiableView
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _attackAnimName;

    private RaycastHit2D[] m_Result = new RaycastHit2D[1];
    private LayerMask _mask;

    public EnemyData EnemyData { get; private set; }

    public Signal<Collider2D> DetectSignal { get; } = new Signal<Collider2D>();

    public override void Init()
    {
        GetComponent<SortingGroup>().sortingLayerName = $"Line{Line}";
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
                if (!_animator.GetBool(_attackAnimName))
                    _animator.SetBool(_attackAnimName, true);

                DetectSignal.Dispatch(m_Result[0].collider);

                yield return new WaitForSeconds(EnemyData.AttackCooldown);
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
}
