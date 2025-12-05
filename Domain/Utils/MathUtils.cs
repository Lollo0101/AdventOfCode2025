namespace AdventOfCode.Utils;

public class MathUtils
{
    public static int Mod(int value, int module)
        => (value % module + module) % module;
}
