namespace AdventOfCode.DayFour.Entities;

public class Rack
{
    public Dictionary<int, Shelf> Shelves { get; set; } = [];
    public required int SizeX { get; set; }
    public required int SizeY { get; set; }

    public int FreeRolls { get; private set; }

    public static Shelf ParseShelf(string line)
    {
        var shelf = new Shelf();

        for (var i = 0; i < line.Length; i++)
        {
            var c = line[i];

            if (c == '@')
            {
                shelf.Rolls.Add(i, new Roll());
            }
        }

        return shelf;
    }

    public override string ToString()
    {
        var rackStr = "";

        for (var x = 0; x < SizeX; x++)
        {
            for (var y = 0; y < SizeY; y++)
            {
                if (!Shelves.TryGetValue(x, out var shelf) || !shelf.Rolls.TryGetValue(y, out var roll))
                {
                    rackStr += ".";
                    continue;
                }

                if (roll.IsRemoved)
                {
                    rackStr += "X";
                    continue;
                }

                rackStr += "@";
            }

            rackStr += Environment.NewLine;
        }

        return rackStr;
    }

    public void CheckFreeRolls()
        => CheckAndRemoveFreeRolls();

    [Obsolete("Method deprecated. Please use CheckAndRemoveFreeRolls instead")]
    private void CheckOnlyFreeRolls()
    {
        foreach (var (y, shelf) in Shelves)
        {
            foreach (var (x, roll) in shelf.Rolls)
            {
                roll.Neighbors += GetNeighbors(x, y);

                Shelves.TryGetValue(y - 1, out var prevShelf);
                roll.Neighbors += GetAnotherShelfNeighbors(prevShelf, x);

                Shelves.TryGetValue(y + 1, out var nextShelf);
                roll.Neighbors += GetAnotherShelfNeighbors(nextShelf, x);

                if (roll.Neighbors < 4)
                {
                    FreeRolls++;
                }
            }
        }
    }

    private void CheckAndRemoveFreeRolls()
    {
        var hasRollRemoved = true;

        while (hasRollRemoved)
        {
            hasRollRemoved = false;

            foreach (var (y, shelf) in Shelves)
            {
                foreach (var (x, roll) in shelf.Rolls)
                {
                    roll.Neighbors = 0;

                    if (roll.IsRemoved)
                    {
                        continue;
                    }

                    roll.Neighbors += GetNeighbors(x, y, true);

                    Shelves.TryGetValue(y - 1, out var prevShelf);
                    roll.Neighbors += GetAnotherShelfNeighbors(prevShelf, x, true);

                    Shelves.TryGetValue(y + 1, out var nextShelf);
                    roll.Neighbors += GetAnotherShelfNeighbors(nextShelf, x, true);

                    if (roll.Neighbors >= 4)
                    {
                        continue;
                    }

                    FreeRolls++;
                    roll.IsRemoved = true;
                    hasRollRemoved = true;
                }
            }
        }
    }

    private int GetNeighbors(int x, int y, bool checkIsRemoved = false)
    {
        var count = 0;
        Shelves.TryGetValue(y, out var shelf);

        if (shelf is null)
        {
            throw new Exception("Shelf of the current roll must exists!");
        }

        if (CheckRoll(shelf.Rolls, x - 1, checkIsRemoved))
        {
            count++;
        }

        if (CheckRoll(shelf.Rolls, x + 1, checkIsRemoved))
        {
            count++;
        }

        return count;
    }

    private static int GetAnotherShelfNeighbors(Shelf? shelf, int x, bool checkIsRemoved = false)
    {
        var count = 0;

        if (shelf is null)
        {
            return count;
        }

        if (CheckRoll(shelf.Rolls, x - 1, checkIsRemoved))
        {
            count++;
        }

        if (CheckRoll(shelf.Rolls, x, checkIsRemoved))
        {
            count++;
        }

        if (CheckRoll(shelf.Rolls, x + 1, checkIsRemoved))
        {
            count++;
        }

        return count;
    }

    private static bool CheckRoll(Dictionary<int, Roll> rolls, int key, bool checkIsRemoved = false)
        => rolls.TryGetValue(key, out var roll) && (!checkIsRemoved || !roll.IsRemoved);
}
