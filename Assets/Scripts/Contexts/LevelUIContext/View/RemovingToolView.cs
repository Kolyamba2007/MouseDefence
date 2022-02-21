using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class RemovingToolView : ToolView 
{
    private int hit;
    private Collider2D[] results = new Collider2D[1];

    private int _layerMask;

    public Signal<IdentifiableView> RemoveTowerSignal { get; } = new Signal<IdentifiableView>();

    protected override void OnEnable()
    {
        base.OnEnable();

        controls.UI.LMB.started += OnClick;
        Init();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        controls.UI.LMB.started -= OnClick;
    }

    private void Init() =>
        _layerMask = LayerMask.GetMask("Tower");

    private void FixedUpdate()
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        hit = Physics2D.OverlapPointNonAlloc(point, results, LayerMask.GetMask("Tower"));
    }

    private void OnClick(CallbackContext context)
    {
        if (hit != 0)
            RemoveTowerSignal.Dispatch(results[0].GetComponent<IdentifiableView>());
    }
}
