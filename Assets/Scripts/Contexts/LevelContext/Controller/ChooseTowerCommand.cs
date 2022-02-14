using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;

public class ChooseTowerCommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }

    [Inject] public IUnitService UnitService { get; set; }
    [Inject] public ICheeseService CheeseService { get; set; }

    [Inject] public TowerView TowerView { get; set; }
    [Inject] public TowerData TowerData { get; set; }

    [Inject] public CreateTowerSignal CreateTowerSignal { get; set; }
    [Inject] public TowerCreatedSignal TowerCreatedSignal { get; set; }
    [Inject] public DestroyTempTowerSignal DestroyTempTowerSignal { get; set; }
    [Inject] public ClearLevelSignal ClearLevelSignal { get; set; }

    public override void Execute() //поменять все на медиатор
    {
        Retain();

        DestroyTempTowerSignal.Dispatch();
        ClearLevelSignal.AddListener(DestroyTempTowerSignal.Dispatch);

        CreateTowerSignal.AddListener((line, position) => {
            CheeseService.SetCount(TowerData.Cost, Enums.Mode.Subtraction);
            UnitService.AddUnit(TowerView, TowerData, line, position);
            TowerCreatedSignal.Dispatch(TowerView.Name);
            DestroyTempTowerSignal.Dispatch();
        });
        DestroyTempTowerSignal.AddListener(OnComplete);

        GameObject selectedTower = new GameObject("SelectedTowerView");
        selectedTower.AddComponent<SelectedTowerView>().Init(TowerData);
        selectedTower.transform.parent = ContextView.transform;
    }

    public void OnComplete()
    {
        ClearLevelSignal.AddListener(DestroyTempTowerSignal.Dispatch);
        CreateTowerSignal.RemoveAllListeners();
        DestroyTempTowerSignal.RemoveAllListeners();

        Release();
    }
}
