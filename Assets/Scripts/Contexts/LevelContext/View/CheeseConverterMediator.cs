using strange.extensions.context.api;
using UnityEngine;

public class CheeseConverterMediator : TowerMediator<CheeseConverterView>
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }
    [Inject] public FinishLevelSignal FinishLevelSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        View.ProduceCheeseSignal.AddListener(OnCreateCheese);
        FinishLevelSignal.AddListener(OnFinishLevel);
    }

    public override void OnRemove()
    {
        base.OnRemove();

        View.StopProducing();
        View.ProduceCheeseSignal.RemoveListener(OnCreateCheese);
        FinishLevelSignal.RemoveListener(OnFinishLevel);
    }

    private void OnCreateCheese() => 
        Instantiate(View.TowerData.ProjectileView, View.SpawnPoint, Quaternion.identity, ContextView.transform)
        .SetData(new ProjectileData(View.Line, View.SpawnPoint, View.TowerData.Damage));

    private void OnFinishLevel(string _) =>
        View.StopProducing();
}
