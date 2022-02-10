using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class FireCommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }
    [Inject] public ProjectileView ProjectileView { get; set; }
    [Inject] public ProjectileData ProjectileData { get; set; }

    public override void Execute()
    {
        GameObject
            .Instantiate<ProjectileView>(ProjectileView, ProjectileData.FirePoint, Quaternion.identity, ContextView.transform)
            .SetData(ProjectileData);
    }
}
