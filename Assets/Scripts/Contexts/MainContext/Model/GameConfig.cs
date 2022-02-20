using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configurations/GameConfig", order = 0)]
public class GameConfig : ScriptableObject
{
    [SerializeField] private string _towersConfig;
    [SerializeField] private string _enemiesConfig;
    [SerializeField] private string _levelConfigsSourcePath;
    [SerializeField] private string _towerViewsSourcePath;
    [SerializeField] private string _enemyViewsSourcePath;
    [SerializeField] private ScriptableObject _settingsConfig;

    [SerializeField] private string _savePath;

    /// <summary>
    /// Return config of towers
    /// </summary>
    public TowersConfig GetTowersConfig => Resources.Load<TowersConfig>(_towersConfig);

    /// <summary>
    /// Return config of enemies
    /// </summary>
    public EnemiesConfig GetEnemiesConfig => Resources.Load<EnemiesConfig>(_enemiesConfig);

    /// <summary>
    /// Return level configs
    /// </summary>
    public LevelConfig[] GetLevelConfigs => Resources.LoadAll<LevelConfig>(_levelConfigsSourcePath);

    /// <summary>
    /// Return tower views
    /// </summary>
    public TowerView[] GetTowerViews => Resources.LoadAll<TowerView>(_towerViewsSourcePath);

    /// <summary>
    /// Return tower views
    /// </summary>
    public EnemyView[] GetEnemyViews => Resources.LoadAll<EnemyView>(_enemyViewsSourcePath);

    /// <summary>
    /// Return config of settings
    /// </summary>
    public ScriptableObject GetSettingsConfig => _settingsConfig;

    public string SavePath => Application.dataPath + "/" + _savePath;

    public static GameConfig Load()
    {
        var data = Resources.LoadAll<GameConfig>("");
        if (data.Length != 1)
        {
            Debug.LogError($"Can't find <b>{nameof(GameConfig)}</b> asset in Resource Folder!");
        }

        return data[0];
    }
}
