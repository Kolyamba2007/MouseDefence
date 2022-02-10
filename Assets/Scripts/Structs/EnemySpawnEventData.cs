using UnityEngine;

[System.Serializable]
public struct EnemySpawnEventData
{
    [SerializeField] private string _enemyID;
    [SerializeField] private int _lineNumber;
    [SerializeField] private float _breakTime;

    public EnemySpawnEventData(string enemyID, int lineNumber, float breakTime)
    {
        _enemyID = enemyID;
        _lineNumber = lineNumber;
        _breakTime = breakTime;
    }

    public string EnemyID => _enemyID;
    public int LineNumber => _lineNumber;
    public float BreakTime => _breakTime;
}
