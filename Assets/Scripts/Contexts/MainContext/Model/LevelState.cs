using System.Collections.Generic;

public class LevelState : ILevelState
{
    public List<LevelConfig> UnlockedLevels { get; } = new List<LevelConfig>();
    public LevelConfig OpenLevel { get; private set; }

    public bool IsNextLocked { get; private set; }

    public void WriteOpenLevel(LevelConfig level)
    {
        OpenLevel = level;
        var nextLevel = OpenLevel.NextLevel;

        if (nextLevel != null && !UnlockedLevels.Contains(nextLevel))
            IsNextLocked = true;
        else
            IsNextLocked = false;
    }

    public void AddNextToUnlocked()
    {
        if (IsNextLocked)
        {
            UnlockedLevels.Add(OpenLevel.NextLevel);
            IsNextLocked = false;
        }
    }
}
