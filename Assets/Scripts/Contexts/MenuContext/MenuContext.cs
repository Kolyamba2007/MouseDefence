using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class MenuContext : MVCSContext
{
    public MenuContext(MonoBehaviour view) : base(view)
    {
    }

    public MenuContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();

        injectionBinder
            .Unbind<ICommandBinder>();

        injectionBinder
            .Bind<ICommandBinder>()
            .To<SignalCommandBinder>()
            .ToSingleton();
    }

    protected override void mapBindings()
    {
        mediationBinder
            .Bind<LevelButtonPanelView>()
            .To<LevelButtonPanelMediator>();

        mediationBinder
            .Bind<LevelButtonView>()
            .To<LevelButtonMediator>();

        commandBinder
            .Bind<SetContextActiveRecursivelySignal>()
            .To<SetContextActiveRecursivelyCommand>();
    }
}
