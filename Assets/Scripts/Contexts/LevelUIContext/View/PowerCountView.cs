using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class PowerCountView : View
{
    [SerializeField] private Text _powerCount;

    public Text PowerCount => _powerCount;
}
