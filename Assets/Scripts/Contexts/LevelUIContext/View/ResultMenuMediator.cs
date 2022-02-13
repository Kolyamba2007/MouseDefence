using UnityEngine;

public class ResultMenuMediator : ViewMediator<ResultMenuView>
{
    [Inject] public FinishLevelSignal FinishLevelSignal { get; set; }
    [Inject] public ClearLevelSignal ClearLevelSignal { get; set; }
    [Inject] public RestartLevelSignal RestartLevelSignal { get; set; }
    [Inject] public SetContextActiveRecursivelySignal SetContextActiveRecursivelySignal { get; set; }

    public override void OnRegister()
    {
        FinishLevelSignal.AddListener((result) => View.Init(result));

        View.ClickMainMenuButton.AddListener(() =>
        {
            gameObject.SetActive(false);
            ClearLevelSignal.Dispatch();
            //RestartLevelSignal.RemoveAllListeners();
            SetContextActiveRecursivelySignal.Dispatch();
        });
        View.ClickRestartButton.AddListener(() =>
        {
            gameObject.SetActive(false);
            ClearLevelSignal.Dispatch();
            RestartLevelSignal.Dispatch();
        });
        View.ClickNextLevelButton.AddListener(() =>
        {
            Debug.Log("NextLevel");
        });
        gameObject.SetActive(false);
    }

    public override void OnRemove()
    {
        FinishLevelSignal.RemoveAllListeners();
        View.ClickMainMenuButton.RemoveAllListeners();
        View.ClickRestartButton.RemoveAllListeners();
        View.ClickNextLevelButton.RemoveAllListeners();
    }
}
