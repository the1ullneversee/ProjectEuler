#If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
#If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

higherBases = {0 : "", 4 : "thousand", 3 : "hundred"}
tensMapping = {0 : "", 1: "ten" ,2 : "twenty", 3 : "thirty", 4 : "forty", 5 : "fifty", 6 : "sixty", 7 : "seventy" , 8: "eighty", 9 : "ninety"}
digitMapping = {0 : "", 1 : "one", 2 : "two" , 3 : "three", 4 : "four", 5 : "five", 6 : "six", 7 : "seven", 8 : "eight", 9 : "nine"}
teenMapping = {10 : "ten" ,11 : "eleven", 12 : "twelve", 13: "thirteen", 14 : "fourteen", 15 : "fithteen", 16 : "sixteen", 17 : "seventeen", 18 : "eighteen", 19 : "nineteen"}

def NumberLetterCount(index):
    sum = 0
    #one,two,three,twelve,thirteen
    
    for i in range(1,index+1):
        digits = NumberToDigits(i)
        sum += DigitsToWord(digits)
    return sum

#convert the number into its corresponding digits
def NumberToDigits(num):
    tempNum = num
    digits = []
    while(tempNum > 0):
        digits.append(tempNum % 10)
        tempNum = (int)(tempNum/10)
    digits.reverse()
    return digits

#covert the digits into its word representation. Algorithm works by going from the top base down, with special cases added in for things like teens.
def DigitsToWord(digits):
    word = ""
    sum = 0
    #zero indexed base
    digits.reverse()
    base = len(digits)-1
    word = ""
    while(base >= 0):
        if base == 3:
            word += digitMapping[digits[base]] + higherBases[base+1]
            len(digitMapping[digits[base]]) + len(higherBases[base])
        elif base == 2:
            word += digitMapping[digits[base]] + "" + higherBases[base+1]
            sum += len(digitMapping[digits[base]]) + len(higherBases[base+1])
            if digits[0] != 0 or digits[1] != 0:
                sum += 3
                word += "and"
        elif base == 1:
            number = (int)(f"{digits[1]}{digits[0]}")
            #zero case
            if number == 0:
                word += ''
            elif number < 20:
                if number in teenMapping:
                    word += teenMapping[number]
                    sum += len(teenMapping[number])
                    break
                else:
                    word += ''

            else:
                word += tensMapping[digits[base]]
                sum += len(tensMapping[digits[base]])
        else:
            word += digitMapping[digits[0]]
            sum += len(digitMapping[digits[0]])
        base -= 1
    print(word)
    return sum

#print(DigitsToWord([2,6]))
#print(DigitsToWord([1,0]))
#print(DigitsToWord([1,3]))
#print(DigitsToWord([3,2,6]))
#print(DigitsToWord([3,0,0]))
#print(DigitsToWord([1,9,9]))
#print(DigitsToWord([1,0,0,0]))

print(f"sum is {NumberLetterCount(1000)}")