using UnityEngine;

public class PauseMenuMediator : ViewMediator<PauseMenuView>
{
    private Controls controls;

    [Inject] public LoadLevelSignal LoadLevelSignal { get; set; }
    [Inject] public FinishLevelSignal FinishLevelSignal { get; set; }
    [Inject] public ClearLevelSignal ClearLevelSignal { get; set; }
    [Inject] public RestartLevelSignal RestartLevelSignal { get; set; }
    [Inject] public SetContextActiveRecursivelySignal SetContextActiveRecursivelySignal { get; set; }

    private void Awake()
    {
        controls = new Controls();
    }

    public override void OnRegister()
    {
        LoadLevelSignal.AddListener((_) => controls.Enable());
        FinishLevelSignal.AddListener((_) => controls.Disable());

        controls.UI.PauseMenu.started += (_) => OnMenuCall();
        View.ClickRestartButton.AddListener(() =>
        {
            OnMenuCall();
            ClearLevelSignal.Dispatch();
            RestartLevelSignal.Dispatch();
        });
        View.ClickMainMenuButton.AddListener(() =>
        {
            controls.Disable();

            OnMenuCall();
            ClearLevelSignal.Dispatch();
            //RestartLevelSignal.RemoveAllListeners();
            SetContextActiveRecursivelySignal.Dispatch();
        });
        View.MenuCallSignal.AddListener(OnMenuCall);
        gameObject.SetActive(false);
    }

    public override void OnRemove()
    {
        LoadLevelSignal.RemoveAllListeners();

        controls.UI.PauseMenu.started -= (_) => OnMenuCall();
        View.ClickRestartButton.RemoveAllListeners();
        View.MenuCallSignal.RemoveAllListeners();

        controls.Disable();
    }

    private void OnMenuCall()
    {
        if(!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
