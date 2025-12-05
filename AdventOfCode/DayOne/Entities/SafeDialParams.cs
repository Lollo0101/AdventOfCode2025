namespace AdventOfCode.DayOne.Entities;

public class SafeDialParams(Direction direction, int distance)
{
    public Direction Direction { get; } = direction;
    public int Distance { get; } = distance;
}
