using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class SelectedTowerView : View
{
    internal void Init(TowerData towerData)
    {
        var cursorPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = new Vector2(cursorPos.x, cursorPos.y);

        var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        spriteRenderer.sprite = towerData.ButtonSprite;
        spriteRenderer.color = new Color(1, 1, 1, .5f);

        var ratio = spriteRenderer.sprite.bounds.size.x / transform.localScale.x;
        transform.localScale /= ratio;

        spriteRenderer.sortingOrder = 5;
    }

    private void Update()
    {
        var cursorPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }
}