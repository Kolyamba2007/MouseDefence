using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "LevelConfig", menuName = "Configurations/LevelConfiguration", order = 4)]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private bool _unlock;

    [SerializeField] private int _cheeseCount;

    [SerializeField] private List<string> _availableTowers = new List<string>();

    [SerializeField] private List<EnemySpawnEventData> _enemiesSpawnData = new List<EnemySpawnEventData>();
    [SerializeField] private float _preparationTime;

    public bool Unlock => _unlock;
    public int CheeseCount => _cheeseCount;
    public List<string> AvailableTowers => _availableTowers;
    public List<EnemySpawnEventData> EnemiesSpawnData => _enemiesSpawnData;
    public float PreparationTime => _preparationTime;

    public LevelConfig NextLevel { get; set; }

    //public void Save()
    //{
    //    EditorUtility.SetDirty(this);
    //    AssetDatabase.SaveAssets();
    //    AssetDatabase.Refresh();
    //}
}
