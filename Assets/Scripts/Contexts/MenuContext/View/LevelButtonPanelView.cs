using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public partial class LevelButtonPanelView : View
{
    [SerializeField] private LevelButtonView _levelButtonPrefab;
    [SerializeField] private Transform _levelButtonsRoot;

    public void Init(LevelConfig[] configs)
    {
        foreach (var config in configs)
        {
            Instantiate(_levelButtonPrefab, _levelButtonsRoot).SetData(config);
        }

        gameObject.SetActive(false);
    }
}
