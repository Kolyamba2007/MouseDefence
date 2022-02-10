using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public partial class LevelButtonView : View
{
    [SerializeField] private Button _button;

    public LevelConfig _config { get; private set; }
    public Signal ButtonClickedSignal { get; } = new Signal();

    private void OnValidate()
    {
        _button = GetComponent<Button>();
    }

    public void SetData(LevelConfig config)
    {
        _config = config;
    }

    protected override void Start()
    {
        base.Start();

        _button.onClick.AddListener(() => ButtonClickedSignal.Dispatch());
    }
}
