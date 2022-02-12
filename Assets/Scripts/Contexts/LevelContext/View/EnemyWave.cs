using RotaryHeart.Lib.SerializableDictionary;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyWave : View
{
    [SerializeField] private SerializableDictionaryBase<int, Transform> _positions;

    private IDictionary<string, EnemyData> _enemyData;

    private List<EnemySpawnEventData> _enemySpawnData;
    private float _preparationTime;

    private Dictionary<string, EnemyView> _enemyPrefab;

    public Coroutine ManufactureCoroutine { get; private set; }

    public Signal<IdentifiableView, IUnitData, int, Vector2> CreateEnemySignal { get;  } = new Signal<IdentifiableView, IUnitData, int, Vector2>();

    public void SetData(LevelConfig levelConfig, GameConfig gameConfig)
    {
        if (_enemyData is null) _enemyData = gameConfig.GetEnemiesConfig.EnemyData;

        _enemySpawnData = levelConfig.EnemiesSpawnData;
        _preparationTime = levelConfig.PreparationTime;

        List<string> temp = new List<string>();
        foreach (EnemySpawnEventData e in _enemySpawnData)
            temp.Add(e.EnemyID);

        _ = temp.Distinct().ToList();

        _enemyPrefab = new Dictionary<string, EnemyView>();
        foreach (var e in gameConfig.GetEnemyViews)
            if (temp.Contains(e.Name)) _enemyPrefab.Add(e.Name, e);
    }

    private IEnumerator Manufacture()
    {
        yield return new WaitForSeconds(_preparationTime);

        foreach (EnemySpawnEventData e in _enemySpawnData)
        {
            CreateEnemySignal.Dispatch(_enemyPrefab[e.EnemyID], _enemyData[e.EnemyID], e.LineNumber, _positions[e.LineNumber].position);
            
            yield return new WaitForSeconds(e.BreakTime);
        }

        yield break;
    }

    public void StartManufacture()
    {
        if (_enemySpawnData is null)
            throw new Exception($"{_enemySpawnData} not set");
        else
            ManufactureCoroutine = StartCoroutine(Manufacture());
    }
}
