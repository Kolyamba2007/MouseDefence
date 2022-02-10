using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class LevelUIContext : MVCSContext
{
    public LevelUIContext(MonoBehaviour view) : base(view)
    {
    }

    public LevelUIContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    override public IContext Start()
    {
        base.Start();
        injectionBinder.GetInstance<GameObject>(ContextKeys.CONTEXT_VIEW).SetActive(false);
        return this;
    }

    protected override void mapBindings()
    {
        mediationBinder
            .Bind<TowerButtonView>()
            .To<TowerButtonMediator>();

        mediationBinder
            .Bind<StartLevelMenuView>()
            .To<StartLevelMenuMediator>();

        commandBinder
            .Bind<LoadLevelSignal>()
            .To<InitLevelUICommand>();
    }
}
