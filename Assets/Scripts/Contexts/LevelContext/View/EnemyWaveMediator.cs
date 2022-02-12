public class EnemyWaveMediator : ViewMediator<EnemyWave>
{
	[Inject] public IUnitService UnitService { get; set; }

	[Inject] public GameConfig GameConfig { get; set; }

	[Inject] public LoadLevelSignal LoadLevelSignal { get; set; }
	[Inject] public StartLevelSignal StartLevelSignal { get; set; }
	[Inject] public ClearLevelSignal ClearLevelSignal { get; set; }

	public override void OnRegister()
	{
		LoadLevelSignal.AddListener((levelConfig) => View.SetData(levelConfig, GameConfig));
		View.CreateEnemySignal.AddListener(UnitService.AddUnit);
		StartLevelSignal.AddListener(View.StartManufacture);
		ClearLevelSignal.AddListener(StopManufacture);
	}

	public override void OnRemove()
	{
		LoadLevelSignal.RemoveAllListeners();
		View.CreateEnemySignal.RemoveAllListeners();
		StartLevelSignal.RemoveAllListeners();
		ClearLevelSignal.RemoveListener(StopManufacture);
	}

	private void StopManufacture()
	{
		if(View.ManufactureCoroutine != null)
			StopCoroutine(View.ManufactureCoroutine);
	}
}
