using System.Collections.Generic;

public interface ILevelService
{
    void LoadLevel(LevelConfig levelConfig);

    void RestartLevel();

    void LoadNextLevel();

    void UnlockNextLevel();

    List<LevelConfig> GetUnlockedLevels();
}
