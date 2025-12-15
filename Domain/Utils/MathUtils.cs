namespace Domain.Utils;

public class MathUtils
{
    public static int Mod(int value, int module)
        => (value % module + module) % module;

    public static int FindMaxIndexInSubArray(List<int> list, int start, int end)
    {
        var currentMax = 0;
        var currentMaxIndex = start;

        for (var i = start; i < start + end; i++)
        {
            if (currentMax >= list[i])
            {
                continue;
            }

            currentMax = list[i];
            currentMaxIndex = i;
        }

        return currentMaxIndex;
    }
}
