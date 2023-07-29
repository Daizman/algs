namespace LeetCode.Problems.Subsets;

public class Solution 
{
    private List<IList<int>> _result = new();
    public IList<IList<int>> Subsets(int[] nums) 
    {
        _result = new();
        MakeSubset(nums, new bool[nums.Length], 0);
        return _result;        
    }

    private void MakeSubset(int[] nums, bool[] included, int position)
    {
        if (position == nums.Length)
        {
            List<int> subset = new();
            for (int i = 0; i < nums.Length; i++)
            {
                if (included[i])
                {
                    subset.Add(nums[i]);
                }
            }
            _result.Add(subset);
            return;
        }
        included[position] = false;
        MakeSubset(nums, included, position + 1);
        included[position] = true;
        MakeSubset(nums, included, position + 1);
    }
}