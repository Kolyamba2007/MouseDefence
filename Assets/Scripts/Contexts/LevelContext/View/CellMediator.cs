public class CellMediator : ViewMediator<CellView>
{
    [Inject] public CreateTowerSignal CreateTowerSignal { get; set; }

    public override void OnRegister()
    {
        View.ClickSignal.AddListener(() => CreateTowerSignal.Dispatch(View.LineNumber, View.transform.position));
    }

    public override void OnRemove()
    {
        View.ClickSignal.RemoveAllListeners();
    }
}
