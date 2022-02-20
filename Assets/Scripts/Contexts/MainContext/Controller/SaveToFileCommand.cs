using strange.extensions.command.impl;
using System;
using System.IO;
using UnityEngine;

public class SaveToFileCommand : Command
{
    [Inject] public ILevelState LevelState { get; set; }

    [Inject] public GameConfig GameConfig { get; set; }

    public override void Execute()
    {
        SaveToFile(GameConfig.SavePath);
    }

    public void SaveToFile(string path)
    {
        string json = JsonUtility.ToJson(new SaveData(LevelState.UnlockedLevels.Count), prettyPrint: true);

        try
        {
            File.WriteAllText(path, contents: json);
        }
        catch (Exception e)
        {
            Debug.Log(message: "{GameLog} => [SaveData] - (<color=red>Error</color>) - SaveToFile -> " + e.Message);
        }
    }
}
