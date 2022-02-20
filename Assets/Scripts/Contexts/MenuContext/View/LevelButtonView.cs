using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public partial class LevelButtonView : View
{
    [SerializeField] private Button _button;

    public LevelConfig LevelConfig { get; private set; }

    public Signal ButtonClickedSignal { get; } = new Signal();

    private void OnValidate()
    {
        _button = GetComponent<Button>();
    }

    protected override void Start()
    {
        base.Start();

        _button.onClick.AddListener(() => ButtonClickedSignal.Dispatch());
    }

    public void Init(bool isUnlocked) =>
        _button.interactable = isUnlocked;

    public void SetData(LevelConfig levelConfig, LevelConfig nextLevel)
    {
        LevelConfig = levelConfig;
        LevelConfig.NextLevel = nextLevel;
    }
}
