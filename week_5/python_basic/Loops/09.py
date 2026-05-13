highest_number = float("-inf")
def choosing_an_integer():
    integer = int(input("enter a number: "))
    return integer

while True:
    my_integer = choosing_an_integer()
    if my_integer > highest_number:
        highest_number = my_integer
    elif my_integer == 0:
        print(highest_number)
        break
    else:
        continue