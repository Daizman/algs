def main():
    ranges = inputRanges()
    dots = wrapRangesWithDots(ranges)
    print(len(dots))
    print(*dots)   

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
    sortedByEnd = sorted(ranges, key=lambda r: r[1], reverse=True)
    current = sortedByEnd.pop()
    while len(sortedByEnd) != 0:
        newCurrent = sortedByEnd.pop()
        if current[1] >= newCurrent[0]:
            continue
        dots.add(current[1])
        current = newCurrent
    dots.add(current[1])

    return dots


if __name__ == "__main__":
    main()
