namespace LeetCode.Problems.GroupAnagrams;

public class Solution 
{
    public IList<IList<string>> GroupAnagrams(string[] strs) 
    {
        Dictionary<string, IList<string>> anagramDict = new();
        foreach(var str in strs)
        {
            var chars = str.ToCharArray();
            Array.Sort(chars);
            var sorted = new string(chars);
            if (!anagramDict.ContainsKey(sorted))
            {
                anagramDict[sorted] = new List<string>();
            }
            anagramDict[sorted].Add(str);
        }

        return anagramDict.Values.ToList();
    }
}
