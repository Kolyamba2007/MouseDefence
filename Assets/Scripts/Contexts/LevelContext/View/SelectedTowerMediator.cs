using strange.extensions.mediation.impl;
using UnityEngine;

public class SelectedTowerMediator : ViewMediator<SelectedTowerView>
{
    [Inject] public DestroyTempTowerSignal DestroyTempTowerSignal { get; set; }

    public override void OnRegister()
    {
        DestroyTempTowerSignal.AddListener(OnNewCreated);
    }

    public override void OnRemove()
    {
        DestroyTempTowerSignal.RemoveListener(OnNewCreated);
        Debug.Log("Mediator OnRemove");
    }

    private void OnNewCreated()
    {
        Destroy(View.gameObject);
    }
}
