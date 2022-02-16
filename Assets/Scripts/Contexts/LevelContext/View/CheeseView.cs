using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheeseView : ProjectileView, IPointerClickHandler
{
    public Signal ClickSignal { get; } = new Signal();

    public override void Init() =>
        GetComponent<SpriteRenderer>().sortingLayerName = $"Line{ProjectileData.LineNumber}";

    protected override void Start()
    {
        base.Start();

        Destroy(gameObject, 7f);
    }

    public void OnPointerClick(PointerEventData eventData) =>
        ClickSignal.Dispatch();
}
