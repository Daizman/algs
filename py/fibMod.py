def fib_mod(n, m):
    fib_num_accumulation = [0, 1]
    i = 2
    # https://en.wikipedia.org/wiki/Pisano_period
    while True:
        prev_number = fib_num_accumulation[i - 1]
        current_number = (prev_number + fib_num_accumulation[i - 2]) % m
        if prev_number == 0 and current_number == 1:
            fib_num_accumulation.pop()
            break
        fib_num_accumulation.append(current_number)
        i += 1
    
    return fib_num_accumulation[n % len(fib_num_accumulation)]


def main():
    n, m = map(int, input().split())
    # need to find: Fib_n % m
    print(fib_mod(n, m))


if __name__ == "__main__":
    main()
