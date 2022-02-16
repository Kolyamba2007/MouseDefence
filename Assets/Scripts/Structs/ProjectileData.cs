using UnityEngine;

public struct ProjectileData
{
    private int _damage;
    private float _speed;
    private float _fireDistance;
    private Vector2 _spawnPoint;
    private int _lineNumber;

    public ProjectileData(int damage, Vector2 spawnPoint, int lineNumber)
    {
        _damage = damage;
        _speed = default;
        _fireDistance = default;
        _spawnPoint = spawnPoint;
        _lineNumber = lineNumber;
    }

    public ProjectileData(int damage, float speed, float fireDistance, Vector2 spawnPoint, int lineNumber)
    {
        _damage = damage;
        _speed = speed;
        _fireDistance = fireDistance;
        _spawnPoint = spawnPoint;
        _lineNumber = lineNumber;
    }

    public int Damage => _damage;
    public float Speed => _speed;
    public float FireDistance => _fireDistance;
    public Vector2 SpawnPoint => _spawnPoint;
    public int LineNumber => _lineNumber;
}
