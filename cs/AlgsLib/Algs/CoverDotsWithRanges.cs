namespace AlgsLib.Algs;

public static class CoverDotsWithRanges
{
    /*
    Множество точек на прямой {x1, ..., xn}
    Вывести: min кол-во отрезков длины 1, которыми можно покрыть все точки
    */
    public static int Run(double[] input)
    {
        int length = input.Length;
        var solution = new List<(double, double)>();

        int i = 0;
        var sorted = input.OrderBy(el => el).ToArray();
        while (i < length)
        {
            (var l, var r) = (sorted[i], sorted[i] + 1);
            solution.Add((l, r));
            i++;
            while (i < length && sorted[i] <= r)
            {
                i++;
            }
        }

        return solution.Count;
    }
}