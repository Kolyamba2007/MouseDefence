using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class DisableMenuContextViewCommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    public override void Execute()
    {
        contextView.SetActive(false);
    }
}
