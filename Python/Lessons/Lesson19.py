
#How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
#rules:
#A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
# 1 Jan 1900 was a Monday.
# Thirty days has September,
# April, June and November.
# All the rest have thirty-one,
# Saving February alone,
# Which has twenty-eight, rain or shine.
# And on leap years, twenty-nine.

months = {1 : 31, 2 : 28, 3 : 31, 4 : 30, 5 : 31, 6 : 30, 7 : 31, 8 : 31, 9 : 30, 10 :31, 11 : 30, 12 :31 }
def CountingSundays():
    print("solving")
    sundays = 365/7
    print(sundays)
    #take the number of days modulus 7, and count up to find the start of the day.
    year = 1900
    end = 2000
    day =1
    month = 1
    while( year <= end):
        i = 1
        while(i < 365):
            




CountingSundays()