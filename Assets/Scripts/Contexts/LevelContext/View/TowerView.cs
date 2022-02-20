using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.EventSystems;

public partial class TowerView : IdentifiableView, IPointerClickHandler
{
    public TowerData TowerData { get; private set; }

    public Signal InitFinishSignal { get; } = new Signal();
    public Signal ClickSignal { get; } = new Signal();

    public override void Init()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = $"Line{Line}";
        InitFinishSignal.Dispatch();
    }

    public override void SetData(IUnitData towerData, UnitViewData viewData)
    {
        TowerData = (TowerData)towerData;
        ID = viewData.ID;
        Line = viewData.Line;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        ClickSignal.Dispatch();
    }
}
