namespace AdventOfCode.DayFive.Entities;

public class FreshFoodChecker(List<FreshRange> ranges, List<long> ids)
{
    public long FreshFoodCount { get; private set; }

    private List<FreshRange> _ranges = ranges;

    public static FreshRange ParseRange(string line)
    {
        var rangeSplit = line.Split('-');
        var start = long.Parse(rangeSplit[0]);
        var end = long.Parse(rangeSplit[1]);

        return new FreshRange(start, end);
    }

    public void CheckFreshFoods()
    {
        foreach (var id in ids)
        {
            if (_ranges.Any(r => r.Contains(id)))
            {
                FreshFoodCount++;
            }
        }
    }

    public void CheckFreshFoodCategory()
    {
        _ranges.Sort();
        MergeRanges();

        FreshFoodCount += _ranges.Select(r => r.Count()).Sum();
    }

    private void MergeRanges()
    {
        var newRanges = new List<FreshRange>();

        foreach (var range in _ranges)
        {
            newRanges = MergeOverlappedRanges(newRanges, range);
        }

        _ranges = newRanges;
    }

    private static List<FreshRange> MergeOverlappedRanges(List<FreshRange> ranges, FreshRange range)
    {
        var index = ranges.FindIndex(r => r.PartiallyContains(range) || range.PartiallyContains(r));

        if (index == -1)
        {
            ranges.Add(range);
            return ranges;
        }

        var freshRange = ranges[index];
        var mergedRange = new FreshRange(Math.Min(freshRange.Start, range.Start), Math.Max(freshRange.End, range.End));
        ranges[index] = mergedRange;

        return ranges;
    }
}
