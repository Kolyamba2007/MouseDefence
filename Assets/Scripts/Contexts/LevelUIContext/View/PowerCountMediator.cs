using UnityEngine;

public class PowerCountMediator : ViewMediator<PowerCountView>
{
    [Inject] public UpdatePowerCountSignal UpdatePowerCountSignal { get; set; }
    [Inject] public SetPowerActiveSignal SetPowerActiveSignal { get; set; }

    public override void OnRegister()
    {
        UpdatePowerCountSignal.AddListener(OnCountUpdate);
        SetPowerActiveSignal.AddListener(OnSetActive);
    }

    public override void OnRemove()
    {
        UpdatePowerCountSignal.RemoveListener(OnCountUpdate);
        SetPowerActiveSignal.RemoveListener(OnSetActive);
    }

    private void OnCountUpdate(int count) => View.PowerCount.text = count.ToString();

    private void OnSetActive(bool isActive)
    {
        if(isActive)
            View.PowerCount.color = Color.white;
        else
            View.PowerCount.color = Color.red;
    }
}
