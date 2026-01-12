using AdventOfCode.DaySix.Entities;
using Domain.Base;

namespace AdventOfCode.DaySix;

public class DaySix : IDay
{
    private List<Column> _columns = [];

    public DaySix(List<string> input)
    {
        var columnsDictionary = new Dictionary<int, List<string>>();

        foreach (var line in input)
        {
            var cells = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < cells.Length; i++)
            {
                var cell = cells[i];

                columnsDictionary.TryGetValue(i, out var column);

                if (column is null)
                {
                    var newColumn = new List<string> {cell};
                    columnsDictionary.Add(i, newColumn);
                }
                else
                {
                    column.Add(cell);
                }
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, string.Join(", ", columnsDictionary.Values)));

        // foreach (var column in columnsDictionary.Values)
        // {
        //     _columns.Add(new Column(column[-1], column[..^1]));
        // }
    }

    public void Run() { }
}
