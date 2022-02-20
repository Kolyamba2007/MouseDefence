public interface IPowerService
{
    bool IsPowerActive { get; }

    void SetAvailablePower(int power, Enums.Mode mode);
    void SetRequiredPower(int power, Enums.Mode mode);
}
