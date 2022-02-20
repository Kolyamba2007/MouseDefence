using strange.extensions.mediation.impl;
using UnityEngine;

public partial class LevelButtonPanelView : View
{
    [SerializeField] private LevelButtonView _levelButtonPrefab;
    [SerializeField] private Transform _levelButtonsRoot;

    public void Init(LevelConfig[] configs)
    {
        var length = configs.Length;

        if (length != 0)
        {
            for (int i = 0; i < length - 1; i++)
            {
                var button = Instantiate(_levelButtonPrefab, _levelButtonsRoot);

                button.SetData(configs[i], configs[i + 1]);
            }

            var lastButton = Instantiate(_levelButtonPrefab, _levelButtonsRoot);

            lastButton.SetData(configs[length - 1], configs[0]);
        }

        gameObject.SetActive(false);
    }
}
