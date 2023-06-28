def main():
    m, items = inputBackpack()
    maxCost = collectItems(m, items)
    print("{0:000}".format(maxCost))

def inputBackpack():
    n, m = map(int, input().split())
    items = []
    for _ in range(n):
        cost, weight = map(float, input().split())
        items.append((cost, weight))
    return (m, items)


def collectItems(m, items):
    sortedByCW = sorted(items, key=lambda item: item[0]/item[1], reverse=True)
    totalWeight = 0
    totalCost = 0
    i = 0
    while totalWeight != m and i < len(items):
        item = sortedByCW[i]
        if item[1] <= m - totalWeight:
            totalWeight += item[1]
            totalCost += item[0]
        else:
            diff = m - totalWeight
            totalWeight += diff
            totalCost += diff / item[1] * item[0]
        i += 1
    return totalCost

if __name__ == "__main__":
    main()
