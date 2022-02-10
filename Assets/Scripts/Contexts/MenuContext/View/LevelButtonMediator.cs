using UnityEngine;

public class LevelButtonMediator : ViewMediator<LevelButtonView>
{
	[Inject]
	public LoadLevelSignal LoadLevelSignal { get; set; }

	public override void OnRegister()
	{
		View.ButtonClickedSignal.AddListener(OnViewClick);
	}

	public override void OnRemove()
	{
		View.ButtonClickedSignal.RemoveListener(OnViewClick);
		Debug.Log("Mediator OnRemove");
	}

	private void OnViewClick()
    {
		LoadLevelSignal.Dispatch(View._config);
	}
}
