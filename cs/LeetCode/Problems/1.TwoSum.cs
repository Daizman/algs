namespace LeetCode.Problems.TwoSum;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int numsLength = nums.Length;
        if (numsLength < 2)
        {
            return new int[0];
        }

        var dict = new Dictionary<int, int>();

        for (int i = 0; i < numsLength; i++)
        {
            var curNum = nums[i];
            var numToFind = target - curNum;
            if (dict.ContainsKey(numToFind))
            {
                return new int[] { i, dict[numToFind] };
            }

            dict[curNum] = i;
        }

        return new int[0];
    }
}