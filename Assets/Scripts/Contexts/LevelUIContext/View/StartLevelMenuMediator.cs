public class StartLevelMenuMediator : ViewMediator<StartLevelMenuView>
{
	[Inject] public GameConfig GameConfig { get; set; }

	[Inject] public LoadLevelSignal LoadLevelSignal { get; set; }
	[Inject] public StartLevelSignal StartLevelSignal { get; set; }
	[Inject] public PauseMenuCallSignal PauseMenuCallSignal { get; set; }

	public override void OnRegister()
	{
        View.OnButtonClickSignal.AddListener(() => StartLevelSignal.Dispatch());

		StartLevelSignal.AddListener(() => gameObject.SetActive(false));
		LoadLevelSignal.AddListener((levelConfig) =>
		{
			View.StartButton.interactable = true;
			View.Init(levelConfig, GameConfig);
			gameObject.SetActive(true);
		});
		PauseMenuCallSignal.AddListener((isOpen) => View.StartButton.interactable = !isOpen);
	}

	public override void OnRemove()
	{
		View.OnButtonClickSignal.RemoveAllListeners();

		StartLevelSignal.RemoveAllListeners();
		LoadLevelSignal.RemoveAllListeners();
		PauseMenuCallSignal.RemoveAllListeners();
	}
}
