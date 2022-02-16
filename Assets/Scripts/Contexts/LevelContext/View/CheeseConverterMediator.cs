public class CheeseConverterMediator : TowerMediator<CheeseConverterView>
{
    [Inject] public FinishLevelSignal FinishLevelSignal { get; set; }
    [Inject] public FireSignal FireSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        View.ProduceCheeseSignal.AddListener(OnCreateCheese);
        FinishLevelSignal.AddListener(OnFinishLevel);
    }

    public override void OnRemove()
    {
        base.OnRemove();

        View.StopProducing();
        View.ProduceCheeseSignal.RemoveListener(OnCreateCheese);
        FinishLevelSignal.RemoveListener(OnFinishLevel);
    }

    private void OnCreateCheese() =>
        FireSignal.Dispatch(View.TowerData.ProjectileView, new ProjectileData(View.TowerData.Damage, View.SpawnPoint, View.Line));

    private void OnFinishLevel(string _) =>
        View.StopProducing();
}
