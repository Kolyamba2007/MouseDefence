using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class LevelContext : MVCSContext
{
    public LevelContext(MonoBehaviour view) : base(view)
    {
    }

    public LevelContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    protected override void mapBindings()
    {
        injectionBinder
            .Bind<DestroyTempTowerSignal>()
            .ToSingleton();

        mediationBinder
            .Bind<CellView>()
            .To<CellMediator>();

        mediationBinder
            .Bind<SelectedTowerView>()
            .To<SelectedTowerMediator>();

        mediationBinder
            .Bind<TowerView>()
            .To<TowerMediator>();

        mediationBinder
            .Bind<EnemyView>()
            .To<EnemyMediator>();

        mediationBinder
            .Bind<ProjectileView>()
            .To<ProjectileMediator>();

        mediationBinder
            .Bind<EnemyWave>()
            .To<EnemyWaveMediator>();

        mediationBinder
            .Bind<LosingTrigger>()
            .To<LosingTriggerMediator>();

        commandBinder
            .Bind<ChooseTowerSignal>()
            .To<ChooseTowerCommand>();

        commandBinder
            .Bind<FireSignal>()
            .To<FireCommand>();

        commandBinder
            .Bind<ProduceUnitSignal>()
            .To<ProduceUnitCommand>();

        commandBinder
            .Bind<DestroyUnitSignal>()
            .To<DestroyUnitCommand>();
    }
}