namespace AdventOfCode.DayFour.Entities;

public class Roll(int neighbors = 0, bool isRemoved = false)
{
    public int Neighbors { get; set; } = neighbors;
    public bool IsRemoved { get; set; } = isRemoved;
}
