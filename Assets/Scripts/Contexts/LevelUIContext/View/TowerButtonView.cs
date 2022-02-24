using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public partial class TowerButtonView : View
{
    [SerializeField] private TowerToolView _toolPrefab;

    [SerializeField] private Image _buttonImage;
    [SerializeField] private Text _costText;
    [SerializeField] private Text _nameText;
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _button;

    private Coroutine _coroutine;

    private Transform _selectionPanelRoot;
    private Transform _towerPanelRoot;

    public TowerToolView ToolPrefab => _toolPrefab;
    public Image Image => _buttonImage;
    public Button Button => _button;

    public TowerData TowerData { get; private set; }
    public TowerView TowerPrefab { get; private set; }
    public string id { get; private set; }

    public Signal ButtonClickedSignal { get; } = new Signal();
    public Signal FinishCooldownSignal { get; } = new Signal();

    protected override void Start()
    {
        base.Start();

        GetComponent<Button>().onClick.AddListener(() => ButtonClickedSignal.Dispatch());
    }

    public void Init()
    {
        _buttonImage.sprite = TowerData.ButtonSprite;
        _costText.text = TowerData.Cost.ToString();
        _nameText.text = id;
        _slider.gameObject.SetActive(false);
    }

    public void SetData(string id, TowerData towerData, TowerView towerPrefab, Transform towerPanelRoot)
    {
        TowerData = towerData;
        TowerPrefab = towerPrefab;
        this.id = id;
        _selectionPanelRoot = transform.parent;
        _towerPanelRoot = towerPanelRoot;
    }

    public void ChangeRootTable() =>
        transform.SetParent(transform.parent == _selectionPanelRoot ? _towerPanelRoot : _selectionPanelRoot);

    private IEnumerator Cooldown(float timeCooldown)
    {
        _slider.maxValue = timeCooldown;
        _slider.value = _slider.minValue;
        _slider.gameObject.SetActive(true);

        while (_slider.value < timeCooldown)
        {
            _slider.value += Time.deltaTime;

            yield return null;
        }
        
        _slider.gameObject.SetActive(false);
        FinishCooldownSignal.Dispatch();
    }

    public void StartCooldown() => 
        _coroutine = StartCoroutine(Cooldown(TowerData.Reload));

    public void StopCooldown()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);
    }
}
