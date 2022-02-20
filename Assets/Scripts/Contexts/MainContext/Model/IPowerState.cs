public interface IPowerState
{
    int AvailablePower { get; set; }
    int RequiredPower { get; set; }

    bool isActive { get; set; }
}
