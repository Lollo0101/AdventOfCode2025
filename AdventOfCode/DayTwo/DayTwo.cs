using AdventOfCode.DayTwo.Entities;
using Domain.Base;

namespace AdventOfCode.DayTwo;

public class DayTwo : IDay
{
    private readonly List<IdsRange> _ranges = [];

    public DayTwo(List<string> input)
    {
        foreach (var range in input)
        {
            _ranges.Add(InvalidIdFinder.ParseRange(range));
        }
    }

    public void Run()
    {
        var invalidIdFinder = new InvalidIdFinder();

        foreach (var range in _ranges)
        {
            invalidIdFinder.CheckRangeAndSum(range);
        }

        Console.WriteLine(invalidIdFinder.InvalidIdsSum);
    }
}
