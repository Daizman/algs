namespace LeetCode.Problems.RotateImage;

public class Solution 
{
    public void Rotate(int[][] matrix) 
    {
        if (!matrix.Any())
        {
            return;
        }
        Print(matrix, "before mirror");
        Mirror(matrix);
        Print(matrix, "after mirror");
        // lower triangle
        int i = matrix.Length - 1, j = 0;
        int iPair = 0, jPair = matrix.Length - 1;
        while(i >= 0 && j < matrix.Length)
        {
            (matrix[jPair][j], matrix[i][iPair]) 
            = (matrix[i][iPair], matrix[jPair][j]);
            Print(matrix);
            i--;
            j++;
        }
        i++;
        j--;

        // upper triangle
        while (iPair < matrix.Length && jPair >= 0)
        {
            (matrix[jPair][j], matrix[i][iPair]) 
            = (matrix[i][iPair], matrix[jPair][j]);
            Print(matrix);

            iPair++;
            jPair--;
        }

        // diag
        for (; i < matrix.Length / 2; i++, j--)
        {
            (matrix[i][i], matrix[j][j]) 
            = (matrix[j][j], matrix[i][i]);
            Print(matrix);
        }
    }

    private void Mirror(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for(int j = 0; j < matrix.Length / 2; j++)
            {
                (matrix[i][matrix.Length - 1 - j], matrix[i][j]) 
                = (matrix[i][j], matrix[i][matrix.Length - 1 - j]);
            }
        }
    }

    private void Print(int[][] matrix, string msg = "")
    {
        Console.WriteLine(msg);
        foreach(var row in matrix)
        {
            foreach(var el in row)
            {
                Console.Write($"{el:00}, ");
            }
            Console.WriteLine();
        }
    }
}
