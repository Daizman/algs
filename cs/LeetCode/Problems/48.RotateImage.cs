namespace LeetCode.Problems.RotateImage;

public class Solution 
{
    public void Rotate(int[][] matrix) 
    {
        if (!matrix.Any())
        {
            return;
        }
        // Mirror matrix by vertical middle line
        Mirror(matrix);

        // Mirror matrix by left bottom corner to right top corner line
        int col1 = 0, row1 = matrix.Length - 1;
        int col2 = 0, row2 = matrix.Length - 1;
        while (col1 != matrix.Length - 1 || col2 != matrix.Length - 1
            || row1 != 0 || row2 != 0)
        {
            int pointer1Col = col1, pointer1Row = row1;
            int pointer2Col = col2, pointer2Row = row2;

            while(pointer1Col < pointer2Col && pointer2Row > pointer1Row)
            {
                (matrix[pointer1Row][pointer1Col], matrix[pointer2Row][pointer2Col]) = 
                (matrix[pointer2Row][pointer2Col], matrix[pointer1Row][pointer1Col]);
                pointer1Col++;
                pointer1Row++;
                pointer2Col--;
                pointer2Row--;
            }
            if (row1 > 0)
            {
                row1--;
            }
            else
            {
                col1++;
            }
            if (col2 < matrix.Length - 1)
            {
                col2++;
            }
            else
            {
                row2--;
            }
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
}
