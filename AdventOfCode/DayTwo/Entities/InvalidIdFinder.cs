namespace AdventOfCode.DayTwo.Entities;

public class InvalidIdFinder
{
    public long InvalidIdsSum { get; private set; }

    public static IdsRange ParseRange(string line)
    {
        var rangeSplit = line.Split('-');
        var start = rangeSplit[0];
        var end = rangeSplit[1];

        return new IdsRange(start, end);
    }

    public void CheckRangeAndSum(IdsRange range)
    {
        for (var i = long.Parse(range.Start); i <= long.Parse(range.End); i++)
        {
            if (IsInvalidId(i.ToString()))
            {
                InvalidIdsSum += i;
            }
        }
    }

    private static bool IsInvalidId(string id)
        => IsAnyRepeatedSequenceId(id);

    [Obsolete("Method deprecated. Please use IsAnyRepeatedSequenceId instead")]
    private static bool IsTwiceSequenceId(string id)
        => id[..(id.Length / 2)].Equals(id[(id.Length / 2)..]);

    private static bool IsAnyRepeatedSequenceId(string id)
    {
        if (id.Length == 1)
        {
            return false;
        }

        if (IsAllSameNumber(id))
        {
            return true;
        }

        if (IsOddAndPrimeNumber(id.Length))
        {
            return false;
        }

        const int start = 0;

        for (var end = 1; end <= id.Length / 2; end++)
        {
            if (!IsDivider(end - start, id.Length))
            {
                continue;
            }

            if (id[start] != id[end])
            {
                continue;
            }

            if (!IsRepeated(id, start, end))
            {
                continue;
            }

            return true;
        }

        return false;
    }

    private static bool IsAllSameNumber(string id)
    {
        for (var i = 0; i < id.Length - 1; i++)
        {
            var c = id[i];

            if (!c.Equals(id[i + 1]))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsOddAndPrimeNumber(int idLength)
    {
        for (var i = 1; i < idLength / 2; i++)
        {
            if (idLength % i == 0)
            {
                return false;
            }
        }

        return idLength % 2 == 1;
    }

    private static bool IsDivider(int subStrLength, int idLength)
        => idLength % subStrLength == 0;

    private static bool IsRepeated(string id, int start, int end)
    {
        if (end > id.Length - 1)
        {
            return true;
        }

        var strLen = end - start;
        var startStr = id.Substring(start, strLen);
        var endStr = id.Substring(end, strLen);

        return startStr.Equals(endStr) && IsRepeated(id, end, end + strLen);
    }
}
