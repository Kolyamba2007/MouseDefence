public class StartLevelMenuMediator : ViewMediator<StartLevelMenuView>
{
	[Inject] public GameConfig GameConfig { get; set; }

	[Inject] public LoadLevelSignal LoadLevelSignal { get; set; }
	[Inject] public StartLevelSignal StartLevelSignal { get; set; }

	public override void OnRegister()
	{
        View.OnButtonClickSignal.AddListener(() => StartLevelSignal.Dispatch());

		StartLevelSignal.AddListener(() => gameObject.SetActive(false));
		LoadLevelSignal.AddListener((levelConfig) =>
		{
			gameObject.SetActive(true);
			View.Init(levelConfig, GameConfig);
		});
	}

	public override void OnRemove()
	{
		View.OnButtonClickSignal.RemoveAllListeners();

		StartLevelSignal.RemoveAllListeners();
		LoadLevelSignal.RemoveAllListeners();
	}
}
