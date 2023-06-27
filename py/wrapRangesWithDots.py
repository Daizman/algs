def main():
    ranges = inputRanges()
    sortedByLength = sorted(ranges, key=lambda r: r.len)
    dots = recursiveWrap(sortedByLength.pop(), sortedByLength)
    print(len(dots))
    print(*dots)

class Range:
    def __init__(self, start, end):
        self.start = start
        self.end = end

    def isIntersectRange(self, other):
        return not (other.start > self.end or other.end < self.start)
    
    def intersectionRange(self, other):
        if not self.isIntersectRange(other):
            return None
        if self.end >= other.start and self.start < other.start and self.end < other.end:
            return Range(other.start, self.end)
        if self.start <= other.end and self.end > other.end and self.start > other.start:
            return Range(self.start, other.end)
        if other.start <= self.start and other.end >= self.start:
            return self
        return other

    def containDot(self, dot):
        return dot >= self.start and dot <= self.end

    @property
    def len(self):
        return self.end - self.start
    
    def __str__(self):
        return "[{start}, {end}]".format(start=self.start, end=self.end)    

def inputRanges():
    n = int(input())
    ranges = []
    for _ in range(n):
        start, end = map(int, input().split())
        ranges.append(Range(start, end))
    return ranges


def recursiveWrap(head, tail):
    if len(tail) == 0:
        return [head.end]
    if len(tail) == 1:
        tailEl = tail[0]
        if head.isIntersectRange(tailEl):
            return [head.intersectionRange(tailEl).end]
        else:
            return [head.end, tailEl.end]
    
    save = head
    head = tail.pop()
    dots = recursiveWrap(head, tail)
    isCovered = False
    for dot in dots:
        if save.containDot(dot):
            isCovered = True
            break
    
    if not isCovered:
        headAndOldHead = recursiveWrap(save, [head])
        tailAndOldHead = recursiveWrap(save, tail)
        if len(headAndOldHead) > len(tailAndOldHead):
            dots += tailAndOldHead
        else:
            dots += headAndOldHead
    return dots



if __name__ == "__main__":
    main()
