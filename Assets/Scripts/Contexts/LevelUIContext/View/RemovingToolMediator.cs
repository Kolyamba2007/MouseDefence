public class RemovingToolMediator : ViewMediator<RemovingToolView>
{
    [Inject] public RemoveModeSignal RemoveModeSignal { get; set; }

    public override void OnRegister()
    {
        View.ButtonClickedSignal.AddListener(() => RemoveModeSignal.Dispatch());
    }

    public override void OnRemove()
    {
        View.ButtonClickedSignal.RemoveAllListeners();
    }
}
