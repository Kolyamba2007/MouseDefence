using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(TowerView))]
public class TowerViewGUI : Editor
{
    int _selected;
    List<string> _selection;

    SerializedProperty _id;

    private void OnEnable()
    {
        var gameConfig = GameConfig.Load();

        _id = serializedObject.FindProperty("_name");

        _selection = new List<string>(gameConfig.GetTowersConfig.TowerData.Keys);

        _selected = _selection.FindIndex(x => x == _id.stringValue);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();

        _selected = EditorGUILayout.Popup("Tower", _selected, _selection.ToArray());

        _id.stringValue = _selection[_selected];

        serializedObject.ApplyModifiedProperties();
    }
}
