using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class MainContext : MVCSContext
{
    private const string gameSceneName = "Game";

    public MainContext(MonoBehaviour view) : base(view)
    {
    }

    public MainContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
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

    override public IContext Start()
    {
        base.Start();
        
        injectionBinder.GetInstance<LoadSceneSignal>().Dispatch(gameSceneName);
        return this;
    }

    protected override void mapBindings()
    {
        BindSignals();

        BindServices();

        injectionBinder
            .Bind<IUnitState>()
            .To<UnitState>()
            .ToSingleton()
            .CrossContext();

        injectionBinder
            .Bind<GameConfig>()
            .To(GameConfig.Load())
            .ToSingleton()
            .CrossContext();

        commandBinder
            .Bind<LoadSceneSignal>()
            .To<LoadSceneCommand>();
    }

    private void BindServices()
    {
        injectionBinder
            .Bind<IUnitService>()
            .To<UnitService>()
            .ToSingleton()
            .CrossContext();
    }

    private void BindSignals()
    {
        injectionBinder
            .Bind<LoadLevelSignal>()
            .ToSingleton()
            .CrossContext();//???

        injectionBinder
           .Bind<StartLevelSignal>()
           .ToSingleton()
           .CrossContext();

        injectionBinder
           .Bind<CreateTowerSignal>()
           .ToSingleton()
           .CrossContext();

        injectionBinder
           .Bind<ChooseTowerSignal>()
           .ToSingleton()
           .CrossContext();

        injectionBinder
           .Bind<ProduceUnitSignal>()
           .ToSingleton()
           .CrossContext();

        injectionBinder
           .Bind<DestroyUnitSignal>()
           .ToSingleton()
           .CrossContext();
    }
}
