using AdventOfCode.DayFour.Entities;

namespace AdventOfCode.DayFour;

public class DayFour
{
    private readonly Rack _rack;

    public DayFour(List<string> input)
    {
        _rack = new Rack {SizeX = input.Count, SizeY = input[0].Length};

        for (var i = 0; i < input.Count; i++)
        {
            var line = input[i];
            _rack.Shelves.Add(i, Rack.ParseShelf(line));
        }
    }

    public void Run()
    {
        _rack.CheckFreeRolls();
        Console.WriteLine(_rack.FreeRolls);
    }
}
