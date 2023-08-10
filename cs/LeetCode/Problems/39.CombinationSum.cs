namespace LeetCode.Problems.CombinationSum;

public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target) 
    {
        GenerateSum(candidates, target, new List<int>());
        return _result;
    }

    private readonly List<IList<int>> _result = new();

    private void GenerateSum(int[] candidates, int target, List<int> combination, int index=0)
    {
        if (target == 0)
        {
            _result.Add(new List<int>(combination));
            return;
        }
        if (target < 0)
        {
            return;
        }

        for(int i = index; i < candidates.Length; i++)
        {
            var currentTestElement = candidates[i];
            combination.Add(currentTestElement);
            GenerateSum(candidates, target - currentTestElement, combination, i);
            combination.Remove(currentTestElement);
        }
    }
}
