using AdventOfCode.DayThree.Entities;

namespace AdventOfCode.DayThree;

public class DayThree
{
    private readonly List<Bank> _banks = [];

    public DayThree(List<string> input)
    {
        foreach (var line in input)
        {
            _banks.Add(Escalator.ParseBank(line));
        }
    }

    public void Run()
    {
        var escalator = new Escalator();
        var totalMaxJoltage = 0;

        foreach (var bank in _banks)
        {
            totalMaxJoltage += escalator.GetMaxJoltage(bank);
        }

        Console.WriteLine(totalMaxJoltage);
    }
}
