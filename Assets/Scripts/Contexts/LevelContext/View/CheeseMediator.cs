public class CheeseMediator : ProjectileMediator<CheeseView>
{
    [Inject] public ICheeseService CheeseService { get; set; }

    [Inject] public PauseMenuCallSignal PauseMenuCallSignal { get; set; }
    [Inject] public FinishLevelSignal FinishLevelSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        PauseMenuCallSignal.AddListener(OnPause);
        View.ClickSignal.AddListener(OnClick);
        FinishLevelSignal.AddListener(OnFinishLevel);
    }

    public override void OnRemove()
    {
        base.OnRemove();

        PauseMenuCallSignal.RemoveListener(OnPause);
        View.ClickSignal.RemoveListener(OnClick);
        FinishLevelSignal.RemoveListener(OnFinishLevel);
    }

    private void OnClick()
    {
        CheeseService.SetCount(View.ProjectileData.Damage, Enums.Mode.Addition);
        Destroy(gameObject);
    }

    private void OnPause(bool isOpen)
    {
        if(isOpen)
            View.ClickSignal.RemoveListener(OnClick);
        else
            View.ClickSignal.AddListener(OnClick);
    }

    private void OnFinishLevel(Enums.Result _) =>
        View.ClickSignal.RemoveListener(OnClick);
}
