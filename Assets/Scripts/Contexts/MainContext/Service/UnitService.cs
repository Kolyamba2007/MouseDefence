using System.Linq;
using UnityEngine;

public class UnitService : IUnitService
{
    [Inject] public IUnitState UnitState { get; set; }

    [Inject] public ProduceUnitSignal ProduceUnitSignal { get; set; }
    [Inject] public DestroyUnitSignal DestroyUnitSignal { get; set; }

    public void AddUnit(IdentifiableView view, IUnitData data, int line, Vector2 position)
    {
        ushort id = GetID();

        UnitState.Health.Add(id, data.MaxHealth);
        UnitState.UnitTypes.AddLast(view.GetType().Name);

        ProduceUnitSignal.Dispatch(view, data, new UnitViewData(id, line, position));
    }

    public void Remove(IdentifiableView view) => KillUnit(view);

    public void Remove(IdentifiableView[] views)
    {
        foreach (var view in views)
            KillUnit(view);
    }

    public int Count<T>()
    {
        int count = 0;
        string type = typeof(T).Name;

        foreach(var unitType in UnitState.UnitTypes)
            if (unitType == type) count++;

        return count;
    }

    public void SetDamage(IdentifiableView view, int damage)
    {
        var health = UnitState.Health[view.ID] -= damage;

        if (health <= 0) KillUnit(view);
    }

    private void KillUnit(IdentifiableView view) 
    {
        UnitState.Health.Remove(view.ID);
        UnitState.UnitTypes.Remove(view.GetType().Name);
        DestroyUnitSignal.Dispatch(view);
    }

    private ushort GetID()
    {
        var id = UnitState.Health.Keys;

        if(id.Count != 0)
            return (ushort)(id.Max() + 1);
        else
            return 0;
    }
}
