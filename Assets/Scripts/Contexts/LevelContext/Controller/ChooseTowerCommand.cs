using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;

public class ChooseTowerCommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }

    [Inject] public TowerView TowerView { get; set; }
    [Inject] public TowerData TowerData { get; set; }

    public override void Execute()
    {
        GameObject selectedTower = new GameObject("SelectedTowerView");
        selectedTower.AddComponent<SelectedTowerView>().SetData(TowerData, TowerView);
        selectedTower.transform.parent = ContextView.transform;
    }
}
