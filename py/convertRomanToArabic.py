def convertRomanToArabic(roman):
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

    for i in range(len(roman) - 1, -1, -1):
        if prev_symbol == "" or roman_dict[prev_symbol] <= roman_dict[roman[i]]:
            arabic += roman_dict[roman[i]]
        else:
            arabic -= roman_dict[roman[i]]
        prev_symbol = roman[i]
    
    return arabic


if __name__ == "__main__":
    roman = input().upper()
    print(convertRomanToArabic(roman))
