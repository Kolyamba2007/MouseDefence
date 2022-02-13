public class CheeseCountMediator : ViewMediator<CheeseCountView>
{
    [Inject] public LoadLevelSignal LoadLevelSignal { get; set; }

    public override void OnRegister()
    {
        LoadLevelSignal.AddListener((levelConfig) => OnCountUpdate(levelConfig.CheeseCount));
    }

    public override void OnRemove()
    {
        LoadLevelSignal.RemoveAllListeners();
    }

    private void OnCountUpdate(int count) => View.Init(count.ToString());
}
