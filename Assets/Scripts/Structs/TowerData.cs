﻿using System;
using UnityEngine;

[Serializable]
public struct TowerData : IUnitData
{
    [SerializeField] private Sprite _buttonSprite;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackDistance;
    [SerializeField] private int _cost;
    [SerializeField] private float _cooldown;
    [SerializeField] private int _powerUsage;
    [SerializeField] private ProjectileView _projectileView;
    [SerializeField] private float _projectileSpeed;

    public Sprite ButtonSprite => _buttonSprite;
    public int MaxHealth => _maxHealth;
    public int Damage => _damage;
    public float AttackSpeed => _attackSpeed;
    public float AttackDistance => _attackDistance;
    public int Cost => _cost;
    public float Cooldown => _cooldown;
    public int PowerUsage => _powerUsage;
    public ProjectileView ProjectileView => _projectileView;
    public float ProjectileSpeed => _projectileSpeed;
}