public class ResultMenuMediator : ViewMediator<ResultMenuView>
{
    [Inject] public ILevelService LevelService { get; set; }

    [Inject] public FinishLevelSignal FinishLevelSignal { get; set; }
    [Inject] public ClearLevelSignal ClearLevelSignal { get; set; }
    [Inject] public SetContextActiveRecursivelySignal SetContextActiveRecursivelySignal { get; set; }

    public override void OnRegister()
    {
        FinishLevelSignal.AddListener((result) =>
        {
            View.Init(result.ToString());

            if (result == Enums.Result.Win)
                LevelService.UnlockNextLevel();
        });

        View.ClickMainMenuButton.AddListener(() =>
        {
            gameObject.SetActive(false);
            ClearLevelSignal.Dispatch();
            SetContextActiveRecursivelySignal.Dispatch();
        });
        View.ClickRestartButton.AddListener(() =>
        {
            gameObject.SetActive(false);
            ClearLevelSignal.Dispatch();
            LevelService.RestartLevel();
        });
        View.ClickNextLevelButton.AddListener(() =>
        {
            gameObject.SetActive(false);
            ClearLevelSignal.Dispatch();
            LevelService.LoadNextLevel();
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
