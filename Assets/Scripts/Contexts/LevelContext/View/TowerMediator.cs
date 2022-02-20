using strange.extensions.mediation.impl;

public abstract class TowerMediator<T> : Mediator
{
    [Inject] public T View { get; set; }

    [Inject] public IUnitService UnitService { get; set; }

    [Inject] public ClearLevelSignal ClearLevelSignal { get; set; }
    [Inject] public RemoveModeSignal RemoveModeSignal { get; set; }

    public override void OnRegister()
    {
        RemoveModeSignal.AddListener(()=>
            (View as TowerView).ClickSignal.AddListener(()=>
            {
                (View as TowerView).ClickSignal.RemoveAllListeners();
                DestroyUnit();
            })
        );
        ClearLevelSignal.AddListener(DestroyUnit);
    }

    public override void OnRemove()
    {
        RemoveModeSignal.RemoveAllListeners();
        ClearLevelSignal.RemoveListener(DestroyUnit);
    }

    private void DestroyUnit() => UnitService.Remove(View as IdentifiableView);
}
