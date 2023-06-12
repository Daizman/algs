
namespace AlgsLib.Algs;

public static class GCDAlgorithm
{
    public static int GCD(int a, int b)
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