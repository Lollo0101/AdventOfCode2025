using AdventOfCode.DayOne.Entities;
using Domain.Base;

namespace AdventOfCode.DayOne;

public class DayOne : IDay
{
    private readonly List<SafeDialParams> _safeDialParams = [];

    public DayOne(List<string> input)
    {
        foreach (var line in input)
        {
            _safeDialParams.Add(SafeDial.ParseSafeDialParams(line));
        }
    }

    public void Run()
    {
        var safeDial = new SafeDial();

        foreach (var safeDialParam in _safeDialParams)
        {
            // safeDial.MoveWithZeroCounterOnStop(safeDialParam);
            safeDial.MoveWithZeroCounter(safeDialParam);
        }

        Console.WriteLine(safeDial.ZeroCount);
    }
}
