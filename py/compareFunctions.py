from math import *

functions = {
    "log2log2n": lambda n: log(log(n, 2), 2),
    "sqrt(log4n)": lambda n: sqrt(log(n, 4)),
    "log3n": lambda n: log(n, 3),
    "log2n**2": lambda n: log(n, 2)**2,

    "sqrt(n)": lambda n: sqrt(n),
    "n/log5n": lambda n: n/log(n, 5),
    "log2(n!)": lambda n: log(factorial(n), 2),
    "3**log2n": lambda n: 3**log(n, 2),

    "n**2": lambda n: n**2,
    "7**log2n": lambda n: 7**log(n, 2),
    "log2n**log2n": lambda n: log(n, 2)**log(n, 2),
    "n**log2n": lambda n: n**log(n, 2),

    "n**sqrt(n)": lambda n: n**sqrt(n),
    "2**n": lambda n: 2**n,
    "4**n": lambda n: 4**n,
    "2**3n": lambda n: 2**(3*n),

    "n!": lambda n: factorial(n),
    # "2**2**n": lambda n: 2**(2**n)
}

prev_value = 0
# where is false use math analysis
for name, func in functions.items():
    val = func(1000)
    print(name, ":", "(", val > prev_value, ")")
    prev_value = val
    print()
