using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class ToolView : View
{
    protected Controls controls;

    public Signal RemoveToolSignal { get; } = new Signal();

    protected override void Awake()
    {
        base.Awake();

        controls = new Controls();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        controls.Enable();
        controls.UI.CancelSelection.started += RemoveTool;

        var cursorPos = Mouse.current.position.ReadValue();
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
        Cursor.visible = false;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        controls.UI.CancelSelection.started -= RemoveTool;
        controls.Disable();

        Cursor.visible = true;
    }

    private void RemoveTool(CallbackContext context) =>
        RemoveToolSignal.Dispatch();

    private void Update()
    {
        var cursorPos = Mouse.current.position.ReadValue();
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }
}
