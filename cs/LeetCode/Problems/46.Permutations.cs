namespace LeetCode.Problems.Permutations;

public class Solution
{
    private List<IList<int>> _result = new();

    public IList<IList<int>> Permute(int[] nums)
    {
        _result = new();
        MakePermutations(nums, 0, new int[nums.Length]);
        return _result;
    }

    private void MakePermutations(int[] nums, int position, int[] permutation)
    {
        if (position == nums.Length)
        {
            _result.Add(new List<int>(permutation));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (Array.IndexOf(permutation, nums[i], 0, position) != -1)
            {
                continue;
            }

            permutation[position] = nums[i];
            MakePermutations(nums, position + 1, permutation);
        }
    }
}