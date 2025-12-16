using AdventOfCode.DayFive.Entities;
using Domain.Base;

namespace AdventOfCode.DayFive;

public class DayFive : IDay
{
    private readonly List<FreshRange> _ranges = [];
    private readonly List<long> _ids = [];

    public DayFive(List<string> input)
    {
        foreach (var line in input)
        {
            if (line.Contains('-'))
            {
                _ranges.Add(FreshFoodChecker.ParseRange(line));
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                _ids.Add(long.Parse(line));
            }
        }
    }

    public void Run()
    {
        var freshFoodChecker = new FreshFoodChecker(_ranges, _ids);
        freshFoodChecker.CheckFreshFoodCategory();

        Console.WriteLine(freshFoodChecker.FreshFoodCount);
    }
}
