using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public partial class TowerButtonView : View
{
    private Transform _selectionPanelRoot;
    private Transform _towerPanelRoot;

    public TowerData TowerData { get; private set; }
    public string id { get; private set; }

    public Signal ButtonClickedSignal { get; } = new Signal();

    protected override void Start()
    {
        base.Start();

        GetComponent<Button>().onClick.AddListener(() => ButtonClickedSignal.Dispatch());
    }

    public void Init()
    {
        GetComponent<Image>().sprite = TowerData.ButtonSprite;
        GetComponentInChildren<Text>().text = id;
    }

    public void SetData(string id, TowerData towerData, Transform towerPanelRoot)
    {
        TowerData = towerData;
        this.id = id;
        _selectionPanelRoot = transform.parent;
        _towerPanelRoot = towerPanelRoot;
    }

    public void ChangeRootTable() =>
        transform.SetParent(transform.parent == _selectionPanelRoot ? _towerPanelRoot : _selectionPanelRoot);
}
