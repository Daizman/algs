namespace LeetCode.Problems.RotateImage;

public class Solution 
{
    public void Rotate(int[][] matrix) 
    {
        // Order important
        Transpose(matrix);
        Mirror(matrix);
    }
    
    private void Transpose(int[][] matrix)
    {
        for(int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                (matrix[i][j], matrix[j][i]) =
                (matrix[j][i], matrix[i][j]);
            }
        }
    }

    private void Mirror(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            Array.Reverse(matrix[i]);
        }
    }
}
