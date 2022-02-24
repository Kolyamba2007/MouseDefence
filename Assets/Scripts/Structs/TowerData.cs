using System;
using UnityEngine;

[Serializable]
public struct TowerData : IUnitData
{
    [SerializeField] private Sprite _buttonSprite;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _abilityCooldown;
    [SerializeField] private float _actuationDistance;
    [SerializeField] private int _cost;
    [SerializeField] private float _reload;
    [SerializeField] private int _powerUsage;
    [SerializeField] private ProjectileView _projectileView;
    [SerializeField] private float _projectileSpeed;

    public Sprite ButtonSprite => _buttonSprite;
    public int MaxHealth => _maxHealth;
    public int Damage => _damage;
    public float AbilityCooldown => _abilityCooldown;
    public float ActuationDistance => _actuationDistance;
    public int Cost => _cost;
    public float Reload => _reload;
    public int PowerUsage => _powerUsage;
    public ProjectileView ProjectileView => _projectileView;
    public float ProjectileSpeed => _projectileSpeed;
}