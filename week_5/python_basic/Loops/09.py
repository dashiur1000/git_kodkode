n = 1
highest_number = 0
while True:
    n = int(input("enter a number: "))
    if n > highest_number and n != 0:
        highest_number = n
    elif n == 0:
        print(highest_number)
    else:
        continue
