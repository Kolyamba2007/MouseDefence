public class GeneratorMediator : TowerMediator<GeneratorView>
{
    [Inject] public IPowerService PowerService { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        View.InitFinishSignal.AddListener(() =>
        PowerService.SetAvailablePower(View.TowerData.PowerUsage, Enums.Mode.Addition));
    }

    public override void OnRemove()
    {
        base.OnRemove();

        View.InitFinishSignal.RemoveAllListeners();
        PowerService.SetAvailablePower(View.TowerData.PowerUsage, Enums.Mode.Subtraction);
    }
}
