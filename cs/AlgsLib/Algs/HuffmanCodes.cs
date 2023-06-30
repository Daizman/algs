using System.Text;

namespace AlgsLib.Algs;

public class HuffmanCodes
{
    public static void Run(string stringToCode)
    {
        HuffmanTree tree = new(stringToCode);
        Console.WriteLine($"{tree.CodesDictionary.Count} {tree.CodedString.Length}");
        foreach(var coded in tree.CodesDictionary)
        {
            Console.WriteLine($"{coded.Key}: {coded.Value}");
        }
        Console.WriteLine(tree.CodedString);
    }

    public class HuffmanTree
    {
        public HuffmanNode Root { get; }
        public string CodedString { get; }
        public string InitialString { get; }
        public Dictionary<char, string> CodesDictionary { get; }

        public HuffmanTree(string stringToCode)
        {
            InitialString = stringToCode;
            var frequencyDictionary = GetCharacterFrequencyDictionary(stringToCode);
            Root = BuildTree(frequencyDictionary);
            CodesDictionary = BuildDictionary(stringToCode, Root);
            CodedString = EncodeString(stringToCode, CodesDictionary);
        }

        private static Dictionary<char, int> GetCharacterFrequencyDictionary(string stringToCode)
        {
            Dictionary<char, int> result = new();
            foreach(var character in stringToCode)
            {
                if (result.ContainsKey(character))
                {
                    result[character]++;
                }
                else
                {
                    result[character] = 1;
                }
            }

            return result;
        }

        private static HuffmanNode BuildTree(Dictionary<char, int> frequencyDictionary)
        {
            PrioQueue<HuffmanNode, int> queue = new();
            foreach(var characterWithFrequency in frequencyDictionary)
            {
                HuffmanNode newNode = new(characterWithFrequency.Value, tag: characterWithFrequency.Key);
                queue.Enqueue(newNode, newNode.Frequency);
            }

            while(queue.Count != 1)
            {
                var i = queue.Dequeue();
                var j = queue.Dequeue();
                HuffmanNode newNode = new(i.Frequency + j.Frequency, i, j);
                queue.Enqueue(newNode, newNode.Frequency);
            }

            return queue.Dequeue();
        }

        private static Dictionary<char, string> BuildDictionary(string stringToCode, HuffmanNode root)
        {
            Dictionary<char, string> answer = new();
            HashSet<char> characters = new(stringToCode);

            foreach(var character in characters)
            {
                answer[character] = root.GetCharacterCode(character);
            }

            return answer;
        }

        public static string EncodeString(string stringToCode, Dictionary<char, string> codesDictionary)
        {
            StringBuilder answer = new();
            foreach(var character in stringToCode)
            {
                answer.Append(codesDictionary[character]);
            }

            return answer.ToString();
        }

        public class HuffmanNode
        {
            public int Frequency { get; }
            public HuffmanNode? Left { get; }
            public HuffmanNode? Right { get; }
            public char Tag { get; }

            public HuffmanNode(int frequency, HuffmanNode? left = null, HuffmanNode? right = null, char tag = '\0')
            {
                Frequency = frequency;
                Left = left;
                Right = right;
                Tag = tag;
            }

            public string GetCharacterCode(char character, string code="")
            {
                if (Tag == character)
                {
                    return string.IsNullOrWhiteSpace(code)
                        ? "0"
                        : code;
                }

                if (Left is null || Right is null)
                {
                    return "";
                }

                var leftResult = Left.GetCharacterCode(character, code + "0");
                if (!string.IsNullOrWhiteSpace(leftResult))
                {
                    return leftResult;
                }

                return Right.GetCharacterCode(character, code + "1");
            }
        }
    }
}

class PrioQueue<TEl, TPrio>
    where TPrio : IComparable
{
    private readonly Dictionary<TPrio, List<TEl>> _queue = new();
    private readonly List<TPrio> _prioList = new();
    public int Count => _prioList.Count;

    public void Enqueue(TEl el, TPrio prio)
    {
        if (_queue.ContainsKey(prio))
        {
            _queue[prio].Add(el);
        }
        else
        {
            _queue[prio] = new() { el };
        }
        var index = _prioList.FindIndex(item => item.CompareTo(prio) == 1);
        if (index == -1)
        {
            _prioList.Add(prio);
        }
        else
        {
            _prioList.Insert(index, prio);
        }
    }

    public TEl Dequeue()
    {
        var queueItem = _queue[_prioList[0]];
        var firstByPrio = queueItem[0];
        queueItem.RemoveAt(0);
        _prioList.RemoveAt(0);

        return firstByPrio;
    }
}