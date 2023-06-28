
namespace AlgsLib.Algs;

public static class GCD
{
    public static int Run(int a, int b)
    {
        while(b != 0)
        {
            var reminder = a % b;
            a = b;
            b = reminder;
        }

        return a;
    }
}