using UnityEngine;

public class SelectedTowerMediator : ViewMediator<SelectedTowerView>
{
    [Inject] public IUnitService UnitService { get; set; }
    [Inject] public ICheeseService CheeseService { get; set; }

    [Inject] public CreateTowerSignal CreateTowerSignal { get; set; }
    [Inject] public TowerCreatedSignal TowerCreatedSignal { get; set; }
    [Inject] public DestroyTempTowerSignal DestroyTempTowerSignal { get; set; }
    [Inject] public FinishLevelSignal FinishLevelSignal { get; set; }

    public override void OnRegister()
    {
        DestroyTempTowerSignal.Dispatch();

        DestroyTempTowerSignal.AddListener(OnViewDestroy);
        FinishLevelSignal.AddListener(OnFinishLevel);
        CreateTowerSignal.AddListener(OnTowerCreate);

        View.CancelTowerSelectionSignal.AddListener(DestroyTempTowerSignal.Dispatch);

        View.Init();
    }

    public override void OnRemove()
    {
        DestroyTempTowerSignal.RemoveListener(OnViewDestroy);
        FinishLevelSignal.RemoveListener(OnFinishLevel);
        CreateTowerSignal.RemoveListener(OnTowerCreate);

        View.CancelTowerSelectionSignal.AddListener(DestroyTempTowerSignal.Dispatch);
    }

    private void OnViewDestroy() => 
        Destroy(gameObject);

    private void OnTowerCreate(int line, Vector3 position)
    {
        CheeseService.SetCount(View.TowerData.Cost, Enums.Mode.Subtraction);
        UnitService.AddUnit(View.TowerView, View.TowerData, line, position);
        TowerCreatedSignal.Dispatch(View.TowerView.Name);
        DestroyTempTowerSignal.Dispatch();
    }

    private void OnFinishLevel(string isOpen) =>
        DestroyTempTowerSignal.Dispatch();
}
