namespace AlgsLib.Algs;

public static class FibNumbers
{
    public static int Run(int n)
    {
        int previous = 0;
        int current = 1;

        for(int i = 2; i <= n; i++)
        {
            var newCurrent = previous + current;
            previous = current;
            current = newCurrent;
        }

        return current;
    }
}
