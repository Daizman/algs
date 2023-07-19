def inputRanges():
    n = int(input())
    ranges = []
    for _ in range(n):
        start, end = map(int, input().split())
        ranges.append((start, end))
    return ranges

def wrapRangesWithDots(ranges):
    dots = set()
    # alg
    sortedByEnd = sorted(ranges, key=lambda r: r[1])
    lastAdded = sortedByEnd[0]
    dots.add(lastAdded[1])
    for i in range(1, len(sortedByEnd)):
        cur = sortedByEnd[i]
        if cur[0] > lastAdded[1] or cur[1] < lastAdded[0]:
            dots.add(cur[1])
            lastAdded = cur

    return dots

def main():
    ranges = inputRanges()
    dots = wrapRangesWithDots(ranges)
    print(len(dots))
    print(*dots)   


if __name__ == "__main__":
    main()
