public class EnemyWaveMediator : ViewMediator<EnemyWave>
{
	[Inject] public IUnitService UnitService { get; set; }

	[Inject] public GameConfig GameConfig { get; set; }

	[Inject] public LoadLevelSignal LoadLevelSignal { get; set; }
	[Inject] public StartLevelSignal StartLevelSignal { get; set; }

	public override void OnRegister()
	{
		LoadLevelSignal.AddListener((levelConfig) => View.SetData(levelConfig, GameConfig));
		View.CreateEnemySignal.AddListener(UnitService.AddUnit);
		StartLevelSignal.AddListener(View.StartManufacture);
	}

	public override void OnRemove()
	{
		LoadLevelSignal.RemoveAllListeners();
		View.CreateEnemySignal.RemoveAllListeners();
		StartLevelSignal.RemoveAllListeners();
	}
}
