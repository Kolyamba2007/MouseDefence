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

        mediationBinder
            .Bind<PauseMenuView>()
            .To<PauseMenuMediator>();

        mediationBinder
            .Bind<ResultMenuView>()
            .To<ResultMenuMediator>();

        mediationBinder
            .Bind<CheeseCountView>()
            .To<CheeseCountMediator>();

        mediationBinder
            .Bind<PowerCountView>()
            .To<PowerCountMediator>();

        commandBinder
            .Bind<SetContextActiveRecursivelySignal>()
            .To<SetContextActiveRecursivelyCommand>();

        mediationBinder
            .Bind<RemovingToolButtonView>()
            .To<RemovingToolButtonMediator>();

        injectionBinder
            .Bind<DestroyToolSignal>()
            .ToSingleton();

        mediationBinder
            .Bind<TowerToolView>()
            .To<TowerToolMediator>();

        mediationBinder
            .Bind<RemovingToolView>()
            .To<RemovingToolMediator>();
    }
}
