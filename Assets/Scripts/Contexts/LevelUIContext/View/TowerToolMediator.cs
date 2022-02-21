using UnityEngine;

public class TowerToolMediator : ToolMediator<TowerToolView>
{
    [Inject] public IUnitService UnitService { get; set; }
    [Inject] public ICheeseService CheeseService { get; set; }

    [Inject] public CreateTowerSignal CreateTowerSignal { get; set; }
    [Inject] public TowerCreatedSignal TowerCreatedSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        CreateTowerSignal.AddListener(OnTowerCreate);
    }

    public override void OnRemove()
    {
        base.OnRemove();

        CreateTowerSignal.RemoveListener(OnTowerCreate);
    }

    private void OnTowerCreate(int line, Vector3 position)
    {
        CheeseService.SetCount(View.TowerData.Cost, Enums.Mode.Subtraction);
        UnitService.AddUnit(View.TowerView, View.TowerData, line, position);
        TowerCreatedSignal.Dispatch(View.TowerView.Name);
        DestroyToolSignal.Dispatch();
    }
}
