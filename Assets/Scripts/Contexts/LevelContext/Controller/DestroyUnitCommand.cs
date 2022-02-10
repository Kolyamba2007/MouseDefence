using strange.extensions.command.impl;
using UnityEngine;

public class DestroyUnitCommand : Command
{
    [Inject] public IdentifiableView View { get; set; }

    public override void Execute() => Object.Destroy(View.gameObject);
}
