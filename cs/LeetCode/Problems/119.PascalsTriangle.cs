namespace LeetCode.Problems.PascalsTriangle;

public class Solution 
{
    public IList<IList<int>> Generate(int numRows) 
    {
        List<IList<int>> triangle = new();
        for (int i = 0; i < numRows; i++)
        {
            List<int> triangleRow = new();
            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                {
                    triangleRow.Add(1);
                }
                else
                {
                    triangleRow.Add(triangle[i - 1][j - 1] + triangle[i - 1][j]);
                }
            }
            triangle.Add(triangleRow);
        }

        return triangle;
    }
}
