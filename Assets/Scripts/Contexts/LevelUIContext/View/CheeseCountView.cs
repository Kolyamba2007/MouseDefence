using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class CheeseCountView : View
{
    [SerializeField] private Text _cheeseCount;

    public void Init(string count) => _cheeseCount.text = count;
}
