using System.Text;

namespace AlgsLib.Algs;

public static class HuffmanCoder
{
    public static string Encode(string stringToEncode)
    {
        EncodeInputValidation(stringToEncode);

        var charactersFrequency = CalculateCharactersFrequency(stringToEncode);
        var huffmanCodesTree = BuildHuffmanCodesTree(charactersFrequency);
        var codesDictionary = GetCodesDictionary(huffmanCodesTree);
        var encodedString = Encode(stringToEncode, codesDictionary);

        return encodedString;
    }

    private static void EncodeInputValidation(string stringToEncode)
    {
        if (string.IsNullOrWhiteSpace(stringToEncode))
        {
            throw new ArgumentException("Empty input");
        }
    }

    public static string Decode(string stringToDecode, Dictionary<string, char> codesDictionary)
    {
        DecodeInputValidation(stringToDecode, codesDictionary);

        var currentCode = "";
        StringBuilder initialString = new();
        for (int i = 0; i < stringToDecode.Length; i++)
        {
            currentCode += stringToDecode[i];
            if (codesDictionary.ContainsKey(currentCode))
            {
                initialString.Append(codesDictionary[currentCode]);
                currentCode = "";
            }
        }

        return initialString.ToString();
    }

    private static void DecodeInputValidation(string stringToDecode, Dictionary<string, char> codesDictionary)
    {
        if (string.IsNullOrWhiteSpace(stringToDecode))
        {
            throw new ArgumentException("Empty input");
        }
        if (codesDictionary is null || !codesDictionary.Any())
        {
            throw new ArgumentException("Codes dictionary not presented");
        }
    }

    private static Dictionary<char, int> CalculateCharactersFrequency(string input)
    {
        Dictionary<char, int> charactersFrequency = new();
        foreach(var character in input)
        {
            if (!charactersFrequency.ContainsKey(character))
            {
                charactersFrequency[character] = 0;
            }
            charactersFrequency[character]++;
        }

        return charactersFrequency;
    }

    private static HuffmanNode BuildHuffmanCodesTree(Dictionary<char, int> charactersFrequency)
    {
        PriorityQueue<HuffmanNode, int> queue = new();
        
        foreach(var characterWithFrequency in charactersFrequency)
        {
            HuffmanNode node = new() { Character = characterWithFrequency.Key, Frequency = characterWithFrequency.Value };
            queue.Enqueue(node, node.Frequency);
        }

        while(queue.Count != 1)
        {
            var left = queue.Dequeue();
            var right = queue.Dequeue();

            HuffmanNode node = new()
            {
                Frequency = left.Frequency + right.Frequency,
                Left = left,
                Right = right
            };

            queue.Enqueue(node, node.Frequency);
        }

        return queue.Dequeue();
    }

    private static Dictionary<char, string> GetCodesDictionary(HuffmanNode root)
        => FindCodes(root).ToDictionary(charCode => charCode.Item1, charCode => charCode.Item2);

    private static IEnumerable<(char, string)> FindCodes(HuffmanNode root, string code = "")
    {
        if (root is null)
        {
            yield break;
        }

        if (root.Character.HasValue)
        {
            code = string.IsNullOrWhiteSpace(code)
                ? "0"
                : code;

            yield return (root.Character.Value, code);
        }

        if (root.Left is not null)
        {
            foreach(var charCode in FindCodes(root.Left, code + "0"))
            {
                yield return charCode;
            }
        }

        if (root.Right is not null)
        {
            foreach(var charCode in FindCodes(root.Right, code + "1"))
            {
                yield return charCode;
            }
        }
    }

    private static string Encode(string stringToEncode, Dictionary<char, string> codesDictionary)
    {
        StringBuilder answer = new();

        foreach(var character in stringToEncode)
        {
            answer.Append(codesDictionary[character]);
        }

        return answer.ToString();
    }
}

class HuffmanNode
{
    public char? Character { get; set; }
    public int Frequency { get; set; }
    public HuffmanNode? Left { get; set; }
    public HuffmanNode? Right { get; set; }
}
