using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class InitLevelUICommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject contextView { get; set; }

    [Inject] public LevelConfig LevelConfig { get; set; }

    public override void Execute()
    {
        contextView.SetActive(true);

        Debug.Log($"{LevelConfig}UI loaded...");
    }
}
