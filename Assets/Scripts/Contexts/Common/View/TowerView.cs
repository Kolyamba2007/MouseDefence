using strange.extensions.signal.impl;
using UnityEngine;

public partial class TowerView : IdentifiableView
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public TowerData TowerData { get; private set; }

    public Signal InitFinishSignal { get; } = new Signal();

    public override void Init()
    {
        _spriteRenderer.sortingLayerName = $"Line{Line}";
        InitFinishSignal.Dispatch();
    }

    public override void SetData(IUnitData towerData, UnitViewData viewData)
    {
        TowerData = (TowerData)towerData;
        ID = viewData.ID;
        Line = viewData.Line;
    }
}
