using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.Rendering;

public partial class TowerView : IdentifiableView
{
    [SerializeField] private SortingGroup _sortingGroup;

    public TowerData TowerData { get; private set; }

    public Signal InitFinishSignal { get; } = new Signal();

    public override void Init()
    {
        _sortingGroup.sortingLayerName = $"Line{Line}";
        InitFinishSignal.Dispatch();
    }

    public override void SetData(IUnitData towerData, UnitViewData viewData)
    {
        TowerData = (TowerData)towerData;
        ID = viewData.ID;
        Line = viewData.Line;
    }
}
