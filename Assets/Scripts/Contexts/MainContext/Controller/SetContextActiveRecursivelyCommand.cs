using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class SetContextActiveRecursivelyCommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }

    public override void Execute()
    {
        if(ContextView.activeSelf)
            ContextView.SetActive(false);
        else
            ContextView.SetActive(true);
    }
}
