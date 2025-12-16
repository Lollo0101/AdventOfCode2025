namespace AdventOfCode.DayFive.Entities;

public class FreshRange(long start, long end) : IComparable<FreshRange>
{
    public long Start { get; } = start;
    public long End { get; } = end;

    public override string ToString() => $"{Start} - {End}";

    public long Count()
        => End - Start + 1;

    public bool Contains(long value)
        => Start <= value && value <= End;

    public bool PartiallyContains(FreshRange range)
        => Contains(range.Start) || Contains(range.End);

    public bool FullyContains(FreshRange range)
        => Contains(range.Start) && Contains(range.End);

    public int CompareTo(FreshRange? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (other is null)
        {
            return 1;
        }

        var startComparison = Start.CompareTo(other.Start);

        return startComparison != 0
            ? startComparison
            : End.CompareTo(other.End);
    }
}
