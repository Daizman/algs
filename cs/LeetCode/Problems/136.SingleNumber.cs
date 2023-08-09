namespace LeetCode.Problems.SingleNumber;

public class Solution 
{
    public int SingleNumber(int[] nums) 
    {
        var accumulator = 0;
        foreach(var num in nums)
        {
            // XOR bit operation
            accumulator ^= num;
        }
        return accumulator;
    }
}
