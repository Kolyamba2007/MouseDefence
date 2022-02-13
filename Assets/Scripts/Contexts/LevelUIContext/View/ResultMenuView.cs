using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ResultMenuView : View
{
    [SerializeField] Text _title;

    [SerializeField] Button _mainMenuButton;
    [SerializeField] Button _restartButton;
    [SerializeField] Button _nextLevelButton;

    public Signal ClickMainMenuButton { get; } = new Signal();
    public Signal ClickRestartButton { get; } = new Signal();
    public Signal ClickNextLevelButton { get; } = new Signal();

    protected override void Start()
    {
        base.Start();

        _mainMenuButton.onClick.AddListener(() => ClickMainMenuButton.Dispatch());
        _restartButton.onClick.AddListener(() => ClickRestartButton.Dispatch());
        _nextLevelButton.onClick.AddListener(() => ClickNextLevelButton.Dispatch());
    }

    public void Init(string result)
    {
        switch (result)
        {
            case "Win":
                _title.text = "Win";
                _title.color = Color.green;
                _restartButton.gameObject.SetActive(false);
                _nextLevelButton.gameObject.SetActive(true);
                break;
            case "Loss":
                _title.text = "Loss";
                _title.color = Color.red;
                _restartButton.gameObject.SetActive(true);
                _nextLevelButton.gameObject.SetActive(false);
                break;
            default:
                throw new Exception("View not initialized");
        }
        gameObject.SetActive(true);
    }
}
