public class LosingTriggerMediator : ViewMediator<LosingTrigger>
{
    [Inject] public LoadLevelSignal LoadLevelSignal { get; set; }
    [Inject] public FinishLevelSignal FinishLevelSignal { get; set; }

    public override void OnRegister()
    {
        LoadLevelSignal.AddListener((_) =>
            View.FinishGameSignal.AddOnce(() =>
                FinishLevelSignal.Dispatch(Enums.Result.Loss)));
    }

    public override void OnRemove()
    {
        LoadLevelSignal.RemoveAllListeners();
        View.FinishGameSignal.RemoveAllListeners();
    }
}
