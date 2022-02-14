using Enums;

public interface ICheeseService
{
    void SetCount(int count, Mode mode);
    int Count { get; }
}