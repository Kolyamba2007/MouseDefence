using strange.extensions.command.impl;
using System;
using System.IO;
using UnityEngine;

public class LoadFromFileCommand : Command
{
    [Inject] public ILevelState LevelState { get; set; }

    [Inject] public GameConfig GameConfig { get; set; }

    public override void Execute()
    {
        LoadFromFile(GameConfig.SavePath);
    }

    public void LoadFromFile(string path)
    {
        if (!File.Exists(path))
            CreateNewFile(path);

        try
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            var levels = GameConfig.GetLevelConfigs;

            if (levels.Length >= data.UnlockedLevelsCount)
            {
                for (int i = 0; i < data.UnlockedLevelsCount; i++)
                {
                    LevelState.UnlockedLevels.Add(levels[i]);
                }
            }
            else
            {
                if(levels.Length != 0)
                {
                    CreateNewFile(path);
                    LoadFromFile(path);
                    return;
                }
                else
                    throw new Exception("Level configurations were not loaded ");
            }
        }
        catch (Exception e)
        {
            Debug.Log(message: "{GameLog} - [SaveData] - (<color=red>Error</color>) - LoadFromFile -> " + e.Message);
        }
    }

    public void CreateNewFile(string path)
    {
        string json = JsonUtility.ToJson(new SaveData(1), prettyPrint: true);

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
