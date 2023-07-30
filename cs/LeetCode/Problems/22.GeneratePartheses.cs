namespace LeetCode.Problems.GeneratePartheses;

public class Solution 
{
    public IList<string> GenerateParenthesis(int n)
    {
        _result = new();

        Generate(n);

        return _result;
    }


    private List<string> _result = new();
    private void Generate(int n, string current = "", int openCount = 0, int closeCount = 0)
    {
        if (openCount == n && openCount == closeCount)
        {
            Console.WriteLine(current);
            _result.Add(current);
           return;
        }

        if (openCount < n)
        {
            Generate(n, current + "(", openCount + 1, closeCount);
        }
        if (closeCount < openCount)
        {
            Generate(n, current + ")", openCount, closeCount + 1);
        }
    }
}