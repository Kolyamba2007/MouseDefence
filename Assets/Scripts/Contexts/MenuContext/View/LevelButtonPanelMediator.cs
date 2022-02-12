public class LevelButtonPanelMediator : ViewMediator<LevelButtonPanelView>
{
    [Inject] public GameConfig GameConfig { get; set; }

    public override void OnRegister()
    {
        View.Init(GameConfig.GetLevelConfigs);
    }
}
