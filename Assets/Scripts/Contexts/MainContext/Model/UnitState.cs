using System.Collections.Generic;

public class UnitState : IUnitState
{
    private Dictionary<ushort, int> _health = new Dictionary<ushort, int>();

    public Dictionary<ushort, int> Health  => _health;
}
