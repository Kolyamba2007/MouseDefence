using strange.extensions.signal.impl;
using UnityEngine.EventSystems;

public class CheeseView : ProjectileView, IPointerClickHandler
{
    public Signal ClickSignal { get; } = new Signal();

    protected override void Start()
    {
        base.Start();

        Destroy(gameObject, 7f);
    }

    public void OnPointerClick(PointerEventData eventData) =>
        ClickSignal.Dispatch();
}
