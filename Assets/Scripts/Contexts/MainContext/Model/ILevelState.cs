using System.Collections.Generic;

public interface ILevelState
{
    List<LevelConfig> UnlockedLevels { get; }
    LevelConfig OpenLevel { get; }

    bool IsNextLocked { get; }

    void WriteOpenLevel(LevelConfig level);

    void AddNextToUnlocked();
}
