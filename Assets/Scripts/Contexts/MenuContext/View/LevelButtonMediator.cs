public class LevelButtonMediator : ViewMediator<LevelButtonView>
{
	[Inject] public ILevelService LevelService { get; set; }

	[Inject] public FinishLevelSignal FinishLevelSignal { get; set; }
	[Inject] public SetContextActiveRecursivelySignal SetContextActiveRecursivelySignal { get; set; }

	public override void OnRegister()
	{
		View.ButtonClickedSignal.AddListener(OnViewClick);
		FinishLevelSignal.AddListener(OnFinishLevel);

		InitView();
	}

	public override void OnRemove()
	{
		View.ButtonClickedSignal.RemoveListener(OnViewClick);
		FinishLevelSignal.RemoveListener(OnFinishLevel);
	}

	private void OnViewClick()
    {
		LevelService.LoadLevel(View.LevelConfig);

		SetContextActiveRecursivelySignal.Dispatch();
	}

	private void OnFinishLevel(Enums.Result result)
	{
		if (result == Enums.Result.Win)
			InitView();
	}

	private void InitView()
    {
		var levels = LevelService.GetUnlockedLevels();

		if (levels.Contains(View.LevelConfig))
			View.Init(true);
		else
			View.Init(false);
	}
}
