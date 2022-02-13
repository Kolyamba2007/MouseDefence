public class EnemyWaveMediator : ViewMediator<EnemyWave>
{
	[Inject] public IUnitService UnitService { get; set; }

	[Inject] public GameConfig GameConfig { get; set; }

	[Inject] public LoadLevelSignal LoadLevelSignal { get; set; }
	[Inject] public StartLevelSignal StartLevelSignal { get; set; }
	[Inject] public ClearLevelSignal ClearLevelSignal { get; set; }
	[Inject] public FinishLevelSignal FinishLevelSignal { get; set; }

	public override void OnRegister()
	{
		LoadLevelSignal.AddListener((levelConfig) => View.SetData(levelConfig, GameConfig));
		View.CreateEnemySignal.AddListener(UnitService.AddUnit);
		View.CheckEnemyCountSignal.AddListener(OnCheckEnemyCount);
		StartLevelSignal.AddListener(View.StartManufacture);
		ClearLevelSignal.AddListener(View.StopManufacture);
		FinishLevelSignal.AddListener((_) => View.StopManufacture());
	}

	public override void OnRemove()
	{
		LoadLevelSignal.RemoveAllListeners();
		View.CreateEnemySignal.RemoveListener(UnitService.AddUnit);
		View.CheckEnemyCountSignal.RemoveListener(OnCheckEnemyCount);
		StartLevelSignal.RemoveListener(View.StartManufacture);
		ClearLevelSignal.RemoveListener(View.StopManufacture);
	}

	private void OnCheckEnemyCount()
    {
		if (UnitService.Count<EnemyView>() == 0)
		{
			View.StopManufacture();
			FinishLevelSignal.Dispatch("Win");
		}
	}
}
