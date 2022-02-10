using UnityEngine;

public struct ProjectileData
{
    private int _lineNumber;
    private int _damage;
    private Vector2 _firePoint;

    public ProjectileData(int lineNumber, Vector2 firePoint, int damage)
    {
        _lineNumber = lineNumber;
        _firePoint = firePoint;
        _damage = damage;
    }

    public int LineNumber => _lineNumber;
    public Vector2 FirePoint => _firePoint;
    public int Damage => _damage;
}
