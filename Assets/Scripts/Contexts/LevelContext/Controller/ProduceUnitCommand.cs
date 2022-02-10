using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class ProduceUnitCommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }
    [Inject] public IdentifiableView View { get; set; }
    [Inject] public IUnitData UnitData { get; set; }
    [Inject] public UnitViewData ViewData { get; set; }

    public override void Execute()
    {
        var view = GameObject
            .Instantiate<IdentifiableView>(View, ViewData.Position, Quaternion.identity, ContextView.transform);

        view.SetData(UnitData, ViewData);
        view.Init();
    }
}
