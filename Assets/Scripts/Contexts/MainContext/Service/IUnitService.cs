using UnityEngine;

public interface IUnitService
{
    void AddUnit(IdentifiableView view, IUnitData data, int line, Vector2 position);

    void Remove(IdentifiableView views);

    void Remove(IdentifiableView[] views);

    void SetDamage(IdentifiableView view, int damage);
}
