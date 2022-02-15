using strange.extensions.mediation.impl;

public class ProjectileMediator<T> : Mediator
{
    [Inject] public T View { get; set; }

    [Inject] public IUnitService UnitService { get; set; }

    [Inject] public ClearLevelSignal ClearLevelSignal { get; set; }

    public override void OnRegister()
    {
        ClearLevelSignal.AddListener(DestroyView);
    }

    public override void OnRemove()
    {
        ClearLevelSignal.RemoveListener(DestroyView);
    }

    private void DestroyView() => Destroy(gameObject);
}
