using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(LevelConfig))]
public class LevelConfigGUI : Editor
{
    private LevelConfig _levelConfig;

    SerializedProperty _cheeseCount;
    SerializedProperty _preparationTime;

    private int _towerCount;
    private int[] _towerIndex;
    private List<string> _towerSelection;

    private int _enemyCount;
    private int[] _enemyIndex;
    private int[] _enemyLineNumber;
    private float[] _enemyBreakTime;
    private List<string> _enemySelection;

    private const int _maxLineCount = 5; //change on dynamic?

    private void OnEnable()
    {
        _levelConfig = (LevelConfig)target;
        var gameConfig = GameConfig.Load();

        _cheeseCount = serializedObject.FindProperty("_cheeseCount");
        _preparationTime = serializedObject.FindProperty("_preparationTime");

        _towerSelection = new List<string>();
        foreach (var tower in gameConfig.GetTowerViews)
            _towerSelection.Add(tower.Name);

        _towerCount = _levelConfig.AvailableTowers.Count;
        if (_towerCount > 0)
        {
            _towerIndex = new int[_towerCount];

            for (int i = 0; i < _towerCount; i++)
                _towerIndex[i] = _towerSelection.FindIndex(x => x == _levelConfig.AvailableTowers[i]);
        }

        _enemySelection = new List<string>();
        foreach (var enemy in gameConfig.GetEnemyViews)
            _enemySelection.Add(enemy.Name);

        var enemySpawnData = _levelConfig.EnemiesSpawnData;
        _enemyCount = enemySpawnData.Count;
        if (_enemyCount > 0)
        {
            _enemyIndex = new int[_enemyCount];
            _enemyLineNumber = new int[_enemyCount];
            _enemyBreakTime = new float[_enemyCount];

            for (int i = 0; i < _enemyCount; i++)
            {
                _enemyIndex[i] = _enemySelection.FindIndex(x => x == enemySpawnData[i].EnemyID);
                _enemyLineNumber[i] = enemySpawnData[i].LineNumber;
                _enemyBreakTime[i] = enemySpawnData[i].BreakTime;
            }
        }
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUILayout.Label("Settings", GUILayout.Height(20));
        GUILayout.BeginVertical("box");
            _cheeseCount.intValue = EditorGUILayout.IntField("Cheese Count:", _cheeseCount.intValue);
        GUILayout.EndVertical();

        if (_cheeseCount.intValue < 0) _cheeseCount.intValue = 0;

        GUILayout.Label("Available Towers", GUILayout.Height(20));
        GUILayout.BeginVertical("box");
            _towerCount = EditorGUILayout.IntField("Count:", _towerCount);

            GUILayout.Space(5f);
            GUILayout.Label("ID");

            if (_towerCount < 0) _towerCount = 0;
                if (_towerIndex is null || _towerIndex.Length != _towerCount)
                    _towerIndex = new int[_towerCount];

            _levelConfig.AvailableTowers.Clear();
            for (int i = 0; i < _towerCount; i++)
            {
                _towerIndex[i] = EditorGUILayout.Popup(_towerIndex[i], _towerSelection.ToArray());
                _levelConfig.AvailableTowers.Add(_towerSelection[_towerIndex[i]]);
            }
        GUILayout.EndVertical();

        GUILayout.Label("Enemy Spawn Event", GUILayout.Height(20));
        GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal();
                _enemyCount = EditorGUILayout.IntField("Count:", _enemyCount);
                _preparationTime.floatValue = EditorGUILayout.FloatField("Preparation Time:", _preparationTime.floatValue);
            GUILayout.EndHorizontal();

            GUILayout.Space(5f);
            GUILayout.BeginHorizontal();
                GUILayout.Label("ID");
                GUILayout.Label("Line Number");
                GUILayout.Label("Break Time");
            GUILayout.EndHorizontal();

            if (_preparationTime.floatValue < 0) _preparationTime.floatValue = 0;
            if (_enemyCount < 0) _enemyCount = 0;
            if (_enemyIndex is null || _enemyIndex.Length != _enemyCount)
            {
                _enemyIndex = new int[_enemyCount];
                _enemyLineNumber = new int[_enemyCount];
                _enemyBreakTime = new float[_enemyCount];
            }

            _levelConfig.EnemiesSpawnData.Clear();
            if(_enemyCount != 0)
            {
                for (int i = 0; i < _enemyCount - 1; i++)
                {
                    GUILayout.BeginHorizontal();
                        _enemyIndex[i] = EditorGUILayout.Popup(_enemyIndex[i], _enemySelection.ToArray());
                        _enemyLineNumber[i] = EditorGUILayout.IntField(_enemyLineNumber[i]);
                        _enemyBreakTime[i] = EditorGUILayout.FloatField(_enemyBreakTime[i]);
                    GUILayout.EndHorizontal();

                    if (_enemyLineNumber[i] < 1 || _enemyLineNumber[i] > _maxLineCount) _enemyLineNumber[i] = 1;
                    if (_enemyBreakTime[i] < 0) _enemyBreakTime[i] = 0;

                    _levelConfig.EnemiesSpawnData.Add(new EnemySpawnEventData(_enemySelection[_enemyIndex[i]], _enemyLineNumber[i], _enemyBreakTime[i]));
                }

                int last = _enemyCount - 1;
                GUILayout.BeginHorizontal();
                    _enemyIndex[last] = EditorGUILayout.Popup(_enemyIndex[last], _enemySelection.ToArray());
                    _enemyLineNumber[last] = EditorGUILayout.IntField(_enemyLineNumber[last]);
                    EditorGUILayout.FloatField(0);
                GUILayout.EndHorizontal();

                if (_enemyLineNumber[last] < 1 || _enemyLineNumber[last] > _maxLineCount) _enemyLineNumber[last] = 1;

                _levelConfig.EnemiesSpawnData.Add(new EnemySpawnEventData(_enemySelection[_enemyIndex[last]], _enemyLineNumber[last], 0));
            }
        GUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();

        if (GUI.changed)
            EditorUtility.SetDirty(_levelConfig);
    }
}
