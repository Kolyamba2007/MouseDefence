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

    public void Init(LevelConfig levelConfig, TowersConfig towersConfig)
    {
        foreach (var tower in levelConfig.AvailableTowers)
        {
            var view = GameObject.Instantiate(_towerButtonPrefab, _selectionPanelRoot);

            view.SetData(tower, towersConfig.TowerData[tower], _towerPanelRoot);
            view.Init();
        }
    }
}
