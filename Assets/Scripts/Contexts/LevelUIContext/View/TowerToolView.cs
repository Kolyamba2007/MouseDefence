using UnityEngine;
using UnityEngine.UI;

public partial class TowerToolView : ToolView
{
    public TowerData TowerData { get; private set; }
    public TowerView TowerView { get; private set; }

    public void Init()
    {
        var image = GetComponent<Image>();

        image.sprite = TowerData.ButtonSprite;
        image.color = new Color(1, 1, 1, .5f);
    }

    public void SetData(TowerData towerData, TowerView prefab)
    {
        TowerData = towerData;
        TowerView = prefab;
    }
}