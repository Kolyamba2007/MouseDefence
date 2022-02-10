using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.EventSystems;
using UnityEngine;

public class CellView : View, IPointerClickHandler
{
    [SerializeField] private int _lineNumber;
    public int LineNumber => _lineNumber;
    public Signal ClickSignal { get; } = new Signal();

    public void OnPointerClick(PointerEventData eventData) => ClickSignal.Dispatch();
}
