public class LevelButtonMediator : ViewMediator<LevelButtonView>
{
	[Inject] public LoadLevelSignal LoadLevelSignal { get; set; }
	[Inject] public RestartLevelSignal RestartLevelSignal { get; set; }
	[Inject] public SetContextActiveRecursivelySignal SetContextActiveRecursivelySignal { get; set; }

	public override void OnRegister()
	{
		View.ButtonClickedSignal.AddListener(OnViewClick);
	}

	public override void OnRemove()
	{
		View.ButtonClickedSignal.RemoveListener(OnViewClick);
	}

	private void OnViewClick()
    {
		LoadLevelSignal.Dispatch(View._config);

		RestartLevelSignal.RemoveAllListeners();
		RestartLevelSignal.AddListener(() => LoadLevelSignal.Dispatch(View._config));

		SetContextActiveRecursivelySignal.Dispatch();
	}
}
