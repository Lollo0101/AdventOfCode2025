using AdventOfCode.Utils;

namespace AdventOfCode.DayOne.Entities;

public class SafeDial
{
    public int ZeroCount { get; private set; }

    private const int Combinations = 100;
    private int _currentPosition = 50;

    public static SafeDialParams ParseSafeDialParams(string line)
    {
        var direction = line[..1].ToUpper();
        var distance = int.Parse(line[1..]);

        return new SafeDialParams(
            direction.Equals("R")
                ? Direction.Right
                : Direction.Left,
            distance
        );
    }

    [Obsolete("Method deprecated. Please use MoveWithZeroCounter instead.")]
    public void MoveWithZeroCounterOnStop(SafeDialParams safeDialParams)
    {
        switch (safeDialParams.Direction)
        {
            case Direction.Right:
                GoRight(safeDialParams.Distance);
                break;

            case Direction.Left:
                GoLeft(safeDialParams.Distance);
                break;

            default:
                throw new Exception("Illegal direction: " + safeDialParams.Direction);
        }

        if (_currentPosition is 0)
        {
            ZeroCount++;
        }
    }

    public void MoveWithZeroCounter(SafeDialParams safeDialParams)
    {
        switch (safeDialParams.Direction)
        {
            case Direction.Right:
                GoRight(safeDialParams.Distance, true);
                break;

            case Direction.Left:
                GoLeft(safeDialParams.Distance, true);
                break;

            default:
                throw new Exception("Illegal direction: " + safeDialParams.Direction);
        }
    }

    private void GoLeft(int distance, bool countZero = false)
    {
        if (countZero && distance > 0)
        {
            ZeroCount += CountZerosDuringLeft(distance);
        }

        _currentPosition = MathUtils.Mod(_currentPosition - distance, Combinations);
    }

    private void GoRight(int distance, bool countZero = false)
    {
        if (countZero)
        {
            ZeroCount += CountZerosDuringRight(distance);
        }

        _currentPosition = MathUtils.Mod(_currentPosition + distance, Combinations);
    }

    private int CountZerosDuringRight(int distance)
        => (_currentPosition + distance) / Combinations;

    private int CountZerosDuringLeft(int distance)
    {
        var clickToZero = _currentPosition is 0
            ? Combinations
            : _currentPosition;

        if (clickToZero > distance)
        {
            return 0;
        }

        return 1 + (distance - clickToZero) / Combinations;
    }
}
