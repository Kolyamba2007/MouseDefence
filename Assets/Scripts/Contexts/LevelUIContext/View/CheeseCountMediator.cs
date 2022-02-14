public class CheeseCountMediator : ViewMediator<CheeseCountView>
{
    [Inject] public ICheeseService CheeseService { get; set; }

    [Inject] public LoadLevelSignal LoadLevelSignal { get; set; }
    [Inject] public UpdateCheeseCountSignal UpdateCheeseCountSignal { get; set; }

    public override void OnRegister()
    {
        UpdateCheeseCountSignal.AddListener(OnCountUpdate);
        LoadLevelSignal.AddListener((levelConfig) => CheeseService.SetCount(levelConfig.CheeseCount, Enums.Mode.Assignment));
    }

    public override void OnRemove()
    {
        UpdateCheeseCountSignal.RemoveListener(OnCountUpdate);
        LoadLevelSignal.RemoveAllListeners();
    }

    private void OnCountUpdate(int count) => View.Init(count.ToString());
}
