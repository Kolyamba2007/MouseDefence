using strange.extensions.mediation.impl;

public abstract class TowerMediator<T> : Mediator
{
    [Inject] public T View { get; set; }

    [Inject] public IUnitService UnitService { get; set; }

    [Inject] public ClearLevelSignal ClearLevelSignal { get; set; }

    public override void OnRegister()
    {
        ClearLevelSignal.AddListener(DestroyUnit);
    }

    public override void OnRemove()
    {
        ClearLevelSignal.RemoveListener(DestroyUnit);
    }

    private void DestroyUnit() => UnitService.Remove(View as IdentifiableView);
}
