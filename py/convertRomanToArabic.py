def convertRomanToArabic(roman: str) -> int:
    roman = roman.upper()
    roman_dict = {
        "I": 1,
        "V": 5,
        "X": 10,
        "L": 50,
        "C": 100,
        "D": 500,
        "M": 1000
    }
    arabic = 0
    prev_symbol = ""

    for symbol in roman:
        if prev_symbol != "" and roman_dict[prev_symbol] < roman_dict[symbol]:
            arabic -= roman_dict[prev_symbol] * 2
        arabic += roman_dict[symbol]
        prev_symbol = symbol
    
    return arabic

def __test():
    romans = {"i": 1, "ii": 2, "iii": 3, "iv": 4, "v": 5, "vi": 6, "vii": 7, 
              "viii": 8, "ix": 9, "x": 10, "xi": 11, "xii": 12, "xiii": 13, 
              "xiv": 14, "xv": 15, "xvi": 16, "xvii": 17, "xviii": 18, 
              "xix": 19, "xx": 20, "xl": 40, "xli": 41, "xlii": 42, "xliii": 43,
              "xliv": 44, "xlv": 45, "xc": 90, "xci": 91, "cxc": 190}
    for (roman, arabic) in romans.items():
        print(convertRomanToArabic(roman) == arabic)

if __name__ == "__main__":
    __test()
