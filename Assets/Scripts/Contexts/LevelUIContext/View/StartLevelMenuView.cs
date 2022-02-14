using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public partial class StartLevelMenuView : View
{
    [SerializeField] private TowerButtonView _towerButtonPrefab;

    [SerializeField] private Button _startLevelButton;

    [SerializeField] private Transform _selectionPanelRoot;
    [SerializeField] private Transform _towerPanelRoot;

    public Signal OnButtonClickSignal { get; } = new Signal();

    protected override void Start()
    {
        base.Start();

        _startLevelButton.onClick.AddListener(() => OnButtonClickSignal.Dispatch());
    }

    public void Init(LevelConfig levelConfig, GameConfig gameConfig)
    {
        var towersConfig = gameConfig.GetTowersConfig;
        var towerViews = gameConfig.GetTowerViews;

        foreach (var tower in levelConfig.AvailableTowers)
        {
            var view = GameObject.Instantiate(_towerButtonPrefab, _selectionPanelRoot);

            foreach (var prefab in towerViews)
                if (prefab.Name == tower)
                {
                    view.SetData(tower, towersConfig.TowerData[tower], prefab, _towerPanelRoot);
                    break;
                }

            view.Init();
        }
    }
}
