def main():
    n = int(input())
    numbers = calculate(n)
    print(len(numbers))
    print(*numbers)


def calculate(n):
    answer = []
    i = 1
    while n > i * 2:
        answer.append(i)
        n -= i
        i += 1
    answer.append(n)
    return answer


if __name__ == "__main__":
    main()
