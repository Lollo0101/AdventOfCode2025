namespace AdventOfCode.DayThree.Entities;

public class Escalator
{
    public static Bank ParseBank(string line)
    {
        var bank = new Bank();

        foreach (var c in line)
        {
            var battery = new Battery {Joltage = c.ToString()};

            bank.Batteries.Add(battery);
        }

        return bank;
    }

    public string GetMaxJoltage(Bank bank)
        => GetMaxJoltageWithTwelveBatteries(bank);

    [Obsolete("Method deprecated. Please use GetMaxJoltageWithXBatteries instead.")]
    private static string GetMaxJoltageWithTwoBatteries(Bank bank)
    {
        var batteriesCount = bank.Batteries.Count;

        var tens = bank.Batteries.GetRange(0, batteriesCount - 1).Max(b => b.Joltage);
        var maxTensIndex = bank.Batteries.FindIndex(0, b => b.Joltage == tens);

        var units = bank.Batteries.GetRange(maxTensIndex + 1, batteriesCount - maxTensIndex - 1).Max(b => b.Joltage);
        return tens + units;
    }
}
