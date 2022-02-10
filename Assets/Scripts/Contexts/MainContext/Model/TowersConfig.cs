using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(fileName = "TowersConfig", menuName = "Configurations/TowersConfiguration", order = 1)]
public class TowersConfig : ScriptableObject
{
    [SerializeField] private SerializableDictionaryBase<string, TowerData> _towerData;

    /// <summary>
    /// Return data of towers
    /// </summary>
    public IDictionary<string, TowerData> TowerData => _towerData;
}
