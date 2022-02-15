using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : View
{
    [SerializeField] Button _restartButton;
    [SerializeField] Button _settingsButton;
    [SerializeField] Button _mainMenuButton;
    [SerializeField] Button _backToGameButton;

    public Signal ClickRestartButton { get; } = new Signal();
    public Signal ClickMainMenuButton { get; } = new Signal();
    public Signal MenuCallSignal { get; } = new Signal();

    protected override void Start()
    {
        base.Start();

        _restartButton.onClick.AddListener(ClickRestartButton.Dispatch);
        _mainMenuButton.onClick.AddListener(ClickMainMenuButton.Dispatch);
        _backToGameButton.onClick.AddListener(MenuCallSignal.Dispatch);
    }
}
