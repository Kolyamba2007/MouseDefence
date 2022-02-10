using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;

public class ChooseTowerCommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }

    [Inject] public IUnitService UnitService { get; set; }

    [Inject] public TowerView TowerView { get; set; }
    [Inject] public TowerData TowerData { get; set; }

    [Inject] public CreateTowerSignal CreateTowerSignal { get; set; }
    [Inject] public DestroyTempTowerSignal DestroyTempTowerSignal { get; set; }

    public override void Execute()
    {
        Retain();

        DestroyTempTowerSignal.Dispatch();
        
        CreateTowerSignal.AddListener((line, position) => { 
            UnitService.AddUnit(TowerView, TowerData, line, position);
            DestroyTempTowerSignal.Dispatch();
        });
        DestroyTempTowerSignal.AddListener(OnComplete);

        GameObject selectedTower = new GameObject("SelectedTowerView"); //поменять на префаб
        selectedTower.AddComponent<SelectedTowerView>().Init(TowerData);
        selectedTower.transform.parent = ContextView.transform;
    }

    public void OnComplete()
    {
        CreateTowerSignal.RemoveAllListeners();
        DestroyTempTowerSignal.RemoveAllListeners();

        Release();
    }
}
