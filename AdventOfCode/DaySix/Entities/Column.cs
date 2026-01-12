namespace AdventOfCode.DaySix.Entities;

public class Column(string operation, List<int> operands)
{
    public int Result =>
        operation switch
        {
            "+" => operands.Sum(),
            "*" => operands.Aggregate((x, y) => x * y),
            _ => throw new NotImplementedException()
        };
}
