using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class RemovingToolView : View
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
}
