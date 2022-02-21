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
        injectionBinder.GetInstance<LoadFromFileSignal>().Dispatch();
        return this;
    }

    protected override void mapBindings()
    {
        BindCommonSignals();

        BindModels();

        BindServices();

        injectionBinder
            .Bind<GameConfig>()
            .To(GameConfig.Load())
            .ToSingleton()
            .CrossContext();

        commandBinder
            .Bind<LoadFromFileSignal>()
            .To<LoadFromFileCommand>();

        commandBinder
            .Bind<SaveToFileSignal>()
            .To<SaveToFileCommand>();

        commandBinder
            .Bind<LoadSceneSignal>()
            .To<LoadSceneCommand>();
    }

    private void BindModels()
    {
        injectionBinder
            .Bind<IUnitState>()
            .To<UnitState>()
            .ToSingleton()
            .CrossContext();

        injectionBinder
            .Bind<ICheeseState>()
            .To<CheeseState>()
            .ToSingleton()
            .CrossContext();

        injectionBinder
            .Bind<ILevelState>()
            .To<LevelState>()
            .ToSingleton()
            .CrossContext();

        injectionBinder
            .Bind<IPowerState>()
            .To<PowerState>()
            .ToSingleton()
            .CrossContext();
    }

    private void BindServices()
    {
        injectionBinder
            .Bind<IUnitService>()
            .To<UnitService>()
            .ToSingleton()
            .CrossContext();

        injectionBinder
            .Bind<ICheeseService>()
            .To<CheeseService>()
            .ToSingleton()
            .CrossContext();

        injectionBinder
            .Bind<ILevelService>()
            .To<LevelService>()
            .ToSingleton()
            .CrossContext();

        injectionBinder
            .Bind<IPowerService>()
            .To<PowerService>()
            .ToSingleton()
            .CrossContext();
    }

    private void BindCommonSignals()
    {
        injectionBinder
            .Bind<LoadLevelSignal>()
            .ToSingleton()
            .CrossContext();

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

        injectionBinder
           .Bind<ClearLevelSignal>()
           .ToSingleton()
           .CrossContext();

        injectionBinder
           .Bind<SetContextActiveRecursivelySignal>()
           .ToSingleton()
           .CrossContext();

        injectionBinder
           .Bind<FinishLevelSignal>()
           .ToSingleton()
           .CrossContext();

        injectionBinder
           .Bind<UpdateCheeseCountSignal>()
           .ToSingleton()
           .CrossContext();

        injectionBinder
           .Bind<TowerCreatedSignal>()
           .ToSingleton()
           .CrossContext();

        injectionBinder
           .Bind<PauseMenuCallSignal>()
           .ToSingleton()
           .CrossContext();

        injectionBinder
            .Bind<SaveToFileSignal>()
            .ToSingleton()
            .CrossContext();

        injectionBinder
            .Bind<SetPowerActiveSignal>()
            .ToSingleton()
            .CrossContext();

        injectionBinder
            .Bind<UpdatePowerCountSignal>()
            .ToSingleton()
            .CrossContext();
    }
}
