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
        var projectile = GameObject
            .Instantiate<ProjectileView>(ProjectileView, ProjectileData.SpawnPoint, Quaternion.identity, ContextView.transform);

        projectile.SetData(ProjectileData);
        projectile.Init();
    }
}
