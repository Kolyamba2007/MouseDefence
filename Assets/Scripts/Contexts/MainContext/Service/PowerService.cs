using Enums;

public class PowerService : IPowerService
{
    [Inject] public IPowerState PowerState { get; set; }

    [Inject] public UpdatePowerCountSignal UpdatePowerCountSignal { get; set; }
    [Inject] public SetPowerActiveSignal SetPowerActiveSignal { get; set; }

    public bool IsPowerActive => PowerState.isActive;

    public void SetAvailablePower(int power, Mode mode)
    {
        switch (mode)
        {
            case Mode.Assignment:
                PowerState.AvailablePower = power;
                break;
            case Mode.Addition:
                PowerState.AvailablePower += power;
                break;
            case Mode.Subtraction:
                PowerState.AvailablePower -= power;
                break;
        }

        UpdatePowerCountSignal.Dispatch(PowerState.AvailablePower);
        SetPowerActive();
    }

    public void SetRequiredPower(int power, Mode mode)
    {
        switch (mode)
        {
            case Mode.Assignment:
                PowerState.RequiredPower = power;
                break;
            case Mode.Addition:
                PowerState.RequiredPower += power;
                break;
            case Mode.Subtraction:
                PowerState.RequiredPower -= power;
                break;
        }

        SetPowerActive();
    }

    private void SetPowerActive()
    {
        if(PowerState.AvailablePower >= PowerState.RequiredPower)
        {
            if (!PowerState.isActive)
            {
                SetPowerActiveSignal.Dispatch(true);
                PowerState.isActive = true;
            }
        }
        else
        {
            if (PowerState.isActive)
            {
                SetPowerActiveSignal.Dispatch(false);
                PowerState.isActive = false;
            }
        }
    }
}
