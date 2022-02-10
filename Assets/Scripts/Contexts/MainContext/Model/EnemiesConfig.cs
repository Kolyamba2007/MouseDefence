using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(fileName = "EnemiesConfig", menuName = "Configurations/EnemiesConfig", order = 3)]
public class EnemiesConfig : ScriptableObject
{
    [SerializeField] private SerializableDictionaryBase<string, EnemyData> _enemyData;

    /// <summary>
    /// Return data of towers
    /// </summary>
    public IDictionary<string, EnemyData> EnemyData => _enemyData;
}
