using UnityEngine;

public partial class TowerView : IdentifiableView
{
    public TowerData TowerData { get; private set; }

    public override void Init() =>
        GetComponent<SpriteRenderer>().sortingLayerName = $"Line{Line}";

    public override void SetData(IUnitData towerData, UnitViewData viewData)
    {
        TowerData = (TowerData)towerData;
        ID = viewData.ID;
        Line = viewData.Line;
    }
}
