using System;
using UnityEngine;

[Serializable]
public struct EnemyData : IUnitData
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _movementSpeed;

    public int MaxHealth => _maxHealth;
    public int Damage => _damage;
    public float AttackCooldown => _attackCooldown;
    public float AttackDistance => _attackDistance;
    public float MovementSpeed => _movementSpeed;
}
