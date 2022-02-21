using strange.extensions.mediation.impl;

public class ToolMediator<T> : Mediator
{
    [Inject] public T View { get; set; }
    [Inject] public DestroyToolSignal DestroyToolSignal { get; set; }
    [Inject] public FinishLevelSignal FinishLevelSignal { get; set; }

    public override void OnRegister()
    {
        DestroyToolSignal.Dispatch();

        DestroyToolSignal.AddListener(OnViewDestroy);
        FinishLevelSignal.AddListener(OnFinishLevel);

        (View as ToolView).RemoveToolSignal.AddListener(DestroyToolSignal.Dispatch);
    }

    public override void OnRemove()
    {
        DestroyToolSignal.RemoveListener(OnViewDestroy);
        FinishLevelSignal.RemoveListener(OnFinishLevel);

        (View as ToolView).RemoveToolSignal.RemoveListener(DestroyToolSignal.Dispatch);
    }

    private void OnViewDestroy() =>
        Destroy(gameObject);

    private void OnFinishLevel(Enums.Result _) =>
        DestroyToolSignal.Dispatch();
}
