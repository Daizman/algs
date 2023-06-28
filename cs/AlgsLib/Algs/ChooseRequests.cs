namespace AlgsLib.Algs;

public static class ChooseRequests
{
    /*
    Дано: множество отрезков на прямой
    Найти: максимальное количество попарно не пересекающихся отрезков
    (Переговорка и заявки на нее)
    */
    public static int Run(List<(double, double)> input)
    {
        var solution = new List<(double, double)>();
        var length = input.Count;

        var sortedByEnd = input.OrderBy(range => range.Item2).ToList();
        for (int i = 0; i < length + 1; i++)
        {
            if (sortedByEnd[i].Item2 < sortedByEnd[i + 1].Item1)
            {
                solution.Add(sortedByEnd[i]);
            }
        }

        return solution.Count;
    }
}