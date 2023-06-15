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
}