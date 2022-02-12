public class TowerButtonMediator : ViewMediator<TowerButtonView>
{
	[Inject] public GameConfig GameConfig { get; set; }
	[Inject] public StartLevelSignal StartLevelSignal { get; set; }
	[Inject] public ChooseTowerSignal ChooseTowerSignal { get; set; }
	[Inject] public ClearLevelSignal ClearLevelSignal { get; set; }

	public override void OnRegister()
	{
		ClearLevelSignal.AddOnce(() => Destroy(gameObject));
		StartLevelSignal.AddListener(OnLevelStart);
		View.ButtonClickedSignal.AddListener(() => View.ChangeRootTable());
	}

	private void OnLevelStart()
	{
		View.ButtonClickedSignal.RemoveAllListeners();
		
        foreach (var tower in GameConfig.GetTowerViews)
        {
			if(tower.Name == View.id)
            {
				View.ButtonClickedSignal.AddListener(() => ChooseTowerSignal.Dispatch(tower, View.TowerData));
				break;
			}
        }
	}

	public override void OnRemove()
	{
		StartLevelSignal.RemoveListener(OnLevelStart);
		View.ButtonClickedSignal.RemoveAllListeners();
	}
}
