from queue import PriorityQueue


def main():
    stringToCode = input()
    root = buildHuffmanCodeTree(stringToCode)
    chars = set(stringToCode)
    dictionary = {}
    for char in chars:
        _, dictionary[char] = root.searchSymbol(char)
    codedString = ""
    for char in stringToCode:
        codedString += dictionary[char]
    print(len(dictionary), len(codedString))
    for symbol, code in dictionary.items():
        print("{symbol}: {code}".format(symbol=symbol, code=code))
    print(codedString)

class TreeNode:
    def __init__(self, value, left = None, right = None, tag = None):
        self.value = value
        self.left = left
        self.right = right
        self.tag = tag
    
    def searchSymbol(self, symbol, code=""):
        if self.tag == symbol:
            return self, code if code != "" else "0"
        if self.left is None and self.right is None:
            return None, None
        left, newCode = self.left.searchSymbol(symbol, code + "0")
        if left is not None:
            return left, newCode
        return self.right.searchSymbol(symbol, code + "1")
    
    def __eq__(self, other):
        return other is not None and self.value == other.value

    def __ne__(self, other):
        return not self.__eq__(other) 
    
    def __gt__(self, other):
        return other is not None and self.value > other.value
    
    def __ge__(self, other):
        return other is not None and self.value >= other.value
    
    def __lt__(self, other):
        return other is not None and self.value < other.value
    
    def __le__(self, other):
        return other is not None and self.value <= other.value
    

def buildHuffmanCodeTree(inputString):
    symbolsFrequency = accumulateSymbolsFrequencyInString(inputString)
    symbolsCount = len(symbolsFrequency)
    
    queue = PriorityQueue()
    for symbol, frequency in symbolsFrequency.items():
        queue.put(TreeNode(frequency, tag=symbol))
    for _ in range(symbolsCount + 1, 2 * symbolsCount):
        inode = queue.get()
        jnode = queue.get()
        codeTree = TreeNode(inode.value + jnode.value, inode, jnode)
        queue.put(codeTree)
    
    root = queue.get()
    return root
    

def accumulateSymbolsFrequencyInString(inputString):
    symbolsFrequency = {}
    for symbol in inputString:
        if symbol in symbolsFrequency.keys():
            symbolsFrequency[symbol] += 1
        else:
            symbolsFrequency[symbol] = 1
    return symbolsFrequency


if __name__ == "__main__":
    main()
