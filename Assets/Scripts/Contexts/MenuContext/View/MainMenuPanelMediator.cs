using UnityEngine;
using UnityEditor;

public class MainMenuPanelMediator : ViewMediator<MainMenuPanelView>
{
	public override void OnRegister()
	{
		View.ClickExitButton.AddListener(OnExit);
	}

	public override void OnRemove()
	{
		View.ClickExitButton.RemoveListener(OnExit);
	}

	private void OnExit()
    {
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
	}
}
