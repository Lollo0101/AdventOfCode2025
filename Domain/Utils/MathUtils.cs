namespace Domain.Utils;

public class MathUtils
{
    public static int Mod(int value, int module)
        => (value % module + module) % module;

    public static int IntPow(int x, int pow)
    {
        var ret = 1;

        while (pow != 0)
        {
            if ((pow & 1) == 1)
            {
                ret *= x;
            }

            x *= x;
            pow >>= 1;
        }

        return ret;
    }
}
