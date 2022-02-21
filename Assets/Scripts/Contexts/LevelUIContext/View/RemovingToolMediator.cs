public class RemovingToolMediator : ToolMediator<RemovingToolView>
{
    [Inject] public IUnitService UnitService { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        View.RemoveTowerSignal.AddListener(UnitService.Remove);
    }

    public override void OnRemove()
    {
        base.OnRemove();

        View.RemoveTowerSignal.RemoveAllListeners();
    }
}