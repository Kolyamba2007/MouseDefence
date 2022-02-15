using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public partial class MainMenuPanelView : View
{
    [SerializeField] private Button _exitButton;

    public Signal ClickExitButton { get; } = new Signal();

    protected override void Start()
    {
        base.Start();

        _exitButton.onClick.AddListener(ClickExitButton.Dispatch);
    }
}
