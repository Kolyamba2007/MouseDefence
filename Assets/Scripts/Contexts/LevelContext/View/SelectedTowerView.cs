using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public partial class SelectedTowerView : View
{
    Controls controls;

    public TowerData TowerData { get; private set; }
    public TowerView TowerView { get; private set; }

    public Signal CancelTowerSelectionSignal { get; } = new Signal();

    protected override void Awake()
    {
        base.Awake();

        controls = new Controls();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        controls.Enable();
        controls.UI.CancelTowerSelection.started += CancelTowerSelection;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        controls.UI.CancelTowerSelection.started -= CancelTowerSelection;
        controls.Disable();
    }

    public void Init()
    {
        var cursorPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = new Vector2(cursorPos.x, cursorPos.y);

        var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        spriteRenderer.sprite = TowerData.ButtonSprite;
        spriteRenderer.color = new Color(1, 1, 1, .5f);

        var ratio = spriteRenderer.sprite.bounds.size.x / transform.localScale.x;
        transform.localScale /= ratio;

        spriteRenderer.sortingOrder = 5;
    }

    public void SetData(TowerData towerData, TowerView prefab)
    {
        TowerData = towerData;
        TowerView = prefab;
    }

    private void CancelTowerSelection(CallbackContext context) => 
        CancelTowerSelectionSignal.Dispatch();

    private void Update()
    {
        var cursorPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }
}