using strange.extensions.mediation.impl;
using UnityEngine;

public abstract class IdentifiableView : View
{
    [HideInInspector, SerializeField] protected string _name;

    public ushort ID { get; protected set; }

    public string Name => _name;

    public abstract void Init();

    public abstract void SetData(IUnitData unitData, UnitViewData viewData);
}
