namespace LeetCode.Problems.LongestSubstringWithoutRepeatingCharacters;

public class Solution
{
    // " ", "dvdf", "abcabcbb"
    public int LengthOfLongestSubstring(string s)
    {
        HashSet<char> template = new();
        int startPos = 0;
        int endPos = 0;
        int maxLength = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (template.Contains(s[i]))
            {
                while (startPos < endPos)
                {
                    char charToRemove = s[startPos];
                    startPos++;
                    template.Remove(charToRemove);
                    if (charToRemove == s[i])
                    {
                        break;
                    }
                }
            }

            template.Add(s[i]);
            endPos = i + 1;
            maxLength = endPos - startPos > maxLength
                ? endPos - startPos
                : maxLength;
        }

        return maxLength;
    }

    public int LengthOfLongestSubstringBest(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        Dictionary<char, int> map = new();
        int startPos = 0;
        int endPos = 0;
        int maxLength = 0;
        while(endPos < s.Length)
        {
            if (map.ContainsKey(s[endPos]))
            {
                startPos = Math.Max(startPos, map[s[endPos]] + 1);
            }

            map[s[endPos]] = endPos;
            endPos++;
            maxLength = Math.Max(maxLength, endPos - startPos);
        }

        return maxLength;
    }
}