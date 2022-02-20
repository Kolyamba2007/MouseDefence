public class CheeseConverterMediator : TowerMediator<CheeseConverterView>
{
    [Inject] public IPowerService PowerService { get; set; }

    [Inject] public FinishLevelSignal FinishLevelSignal { get; set; }
    [Inject] public FireSignal FireSignal { get; set; }
    [Inject] public SetPowerActiveSignal SetPowerActiveSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        View.ProduceCheeseSignal.AddListener(OnCreateCheese);
        FinishLevelSignal.AddListener(OnFinishLevel);
        SetPowerActiveSignal.AddListener(OnSetActive);

        View.InitFinishSignal.AddListener(() =>
        {
            PowerService.SetRequiredPower(View.TowerData.PowerUsage, Enums.Mode.Addition);

            if (PowerService.IsPowerActive)
                View.StartProducing();
        });
    }

    public override void OnRemove()
    {
        base.OnRemove();

        View.StopProducing();

        View.ProduceCheeseSignal.RemoveListener(OnCreateCheese);
        FinishLevelSignal.RemoveListener(OnFinishLevel);
        SetPowerActiveSignal.RemoveListener(OnSetActive);

        View.InitFinishSignal.RemoveAllListeners();
        PowerService.SetRequiredPower(View.TowerData.PowerUsage, Enums.Mode.Subtraction);
    }

    private void OnCreateCheese() =>
        FireSignal.Dispatch(View.TowerData.ProjectileView, new ProjectileData(View.TowerData.Damage, View.SpawnPoint, View.Line));

    private void OnFinishLevel(Enums.Result _) =>
        View.StopProducing();

    private void OnSetActive(bool isActive)
    {
        if (isActive)
            View.StartProducing();
        else
            View.StopProducing();
    }
}
