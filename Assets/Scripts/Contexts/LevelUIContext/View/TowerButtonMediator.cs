using strange.extensions.context.api;
using UnityEngine;

public class TowerButtonMediator : ViewMediator<TowerButtonView>
{
	[Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }

	[Inject] public ICheeseService CheeseService { get; set; }

	[Inject] public StartLevelSignal StartLevelSignal { get; set; }
	[Inject] public ChooseTowerSignal ChooseTowerSignal { get; set; }
	[Inject] public ClearLevelSignal ClearLevelSignal { get; set; }
	[Inject] public UpdateCheeseCountSignal UpdateCheeseCountSignal { get; set; }
	[Inject] public FinishLevelSignal FinishLevelSignal { get; set; }
	[Inject] public TowerCreatedSignal TowerCreatedSignal { get; set; }
	[Inject] public PauseMenuCallSignal PauseMenuCallSignal { get; set; }

	public override void OnRegister()
	{
		ClearLevelSignal.AddOnce(() =>
		{
			View.StopCooldown();
			Destroy(gameObject);
		});
		StartLevelSignal.AddListener(OnLevelStart);
		FinishLevelSignal.AddListener(OnLevelFinish);
		TowerCreatedSignal.AddListener(OnTowerCreate);
		PauseMenuCallSignal.AddListener(OnPauseCall);

		View.ButtonClickedSignal.AddListener(View.ChangeRootTable);
		View.FinishCooldownSignal.AddListener(OnCooldownFinish);
	}

	public override void OnRemove()
	{
		UpdateCheeseCountSignal.RemoveListener(OnCheeseCountUpdate);
		StartLevelSignal.RemoveListener(OnLevelStart);
		FinishLevelSignal.RemoveListener(OnLevelFinish);
		TowerCreatedSignal.RemoveListener(OnTowerCreate);
		PauseMenuCallSignal.RemoveListener(OnPauseCall);

		View.ButtonClickedSignal.RemoveAllListeners();
		View.FinishCooldownSignal.RemoveListener(OnCooldownFinish);
	}

	private void OnLevelStart()
	{
		if (CheeseService.Count < View.TowerData.Cost)
			View.Button.interactable = false;

		View.ButtonClickedSignal.RemoveListener(View.ChangeRootTable);
		UpdateCheeseCountSignal.AddListener(OnCheeseCountUpdate);
		View.ButtonClickedSignal.AddListener(OnClick);
	}

	private void OnCheeseCountUpdate(int count)
	{
		if (count < View.TowerData.Cost)
			View.Button.interactable = false;
        else
			View.Button.interactable = true;
	}

	private void OnTowerCreate(string name)
    {
		if (View.id == name)
		{
			UpdateCheeseCountSignal.RemoveListener(OnCheeseCountUpdate);
			View.Button.interactable = false;
			View.StartCooldown();
		}
	}

	private void OnCooldownFinish()
    {
		UpdateCheeseCountSignal.AddListener(OnCheeseCountUpdate);
		if (CheeseService.Count >= View.TowerData.Cost)
			View.Button.interactable = true;
	}

	private void OnLevelFinish(Enums.Result _) => View.Image.raycastTarget = false;

	private void OnPauseCall(bool isOpen) => View.Image.raycastTarget = !isOpen;

	private void OnClick()
    {
		var tool = Instantiate(View.ToolPrefab, ContextView.transform);

		tool.SetData(View.TowerData, View.TowerPrefab);
		tool.Init();
	}
}
