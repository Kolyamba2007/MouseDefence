using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(EnemyView))]
public class EnemyViewGUI : Editor
{
    int _selected;
    List<string> _selection;

    SerializedProperty _id;

    private void OnEnable()
    {
        var gameConfig = GameConfig.Load();

        _id = serializedObject.FindProperty("_name");

        _selection = new List<string>(gameConfig.GetEnemiesConfig.EnemyData.Keys);

        _selected = _selection.FindIndex(x => x == _id.stringValue);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();

        _selected = EditorGUILayout.Popup("Enemy", _selected, _selection.ToArray());

        _id.stringValue = _selection[_selected];

        serializedObject.ApplyModifiedProperties();
    }
}
