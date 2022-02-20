using System;
using System.Collections.Generic;

public class LevelService : ILevelService
{
    [Inject] public ILevelState LevelState { get; set; }

    [Inject] public LoadLevelSignal LoadLevelSignal { get; set; }
    [Inject] public SaveToFileSignal SaveToFileSignal { get; set; }

    public void LoadLevel(LevelConfig levelConfig)
    {
        LevelState.WriteOpenLevel(levelConfig);

        LoadLevelSignal.Dispatch(levelConfig);
    }

    public void RestartLevel()
    {
        LoadLevel(LevelState.OpenLevel);
    }

    public void LoadNextLevel()
    {
        var level = LevelState.OpenLevel.NextLevel;

        if (level != null && !LevelState.IsNextLocked)
            LoadLevel(level);
        else
            throw new Exception("Next level not written or locked!");
    }

    public void UnlockNextLevel()
    {
        LevelState.AddNextToUnlocked();

        SaveToFileSignal.Dispatch();
    }

    public List<LevelConfig> GetUnlockedLevels() =>
        LevelState.UnlockedLevels;
}
