using AdventOfCode.DayThree.Entities;
using Domain.Base;

namespace AdventOfCode.DayThree;

public class DayThree : IDay
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
        long totalMaxJoltage = 0;

        foreach (var bank in _banks)
        {
            var bankJoltage = escalator.GetMaxJoltage(bank);
            totalMaxJoltage += long.Parse(bankJoltage);
        }

        Console.WriteLine(totalMaxJoltage);
    }
}
