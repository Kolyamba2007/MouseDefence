using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class RemovingToolButtonView : View
{
    [SerializeField] private Image _image;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private Button _button;

    public Button Button => _button;
    public GameObject Prefab => _prefab;
    public Signal ClickSignal { get; } = new Signal();

    private void OnValidate()
    {
        _button = GetComponent<Button>();
    }

    protected override void Start()
    {
        base.Start();

        _button.onClick.AddListener(ClickSignal.Dispatch);
        _button.interactable = false;
    }
}
