public class PowerState : IPowerState
{
    public int AvailablePower { get; set; }
    public int RequiredPower { get; set; }

    public bool isActive { get; set; }
}
