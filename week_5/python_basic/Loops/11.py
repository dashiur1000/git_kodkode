number = int(input("enter a int number: "))
new_number = 0
while number > 0:
    number2 = number % 10
    new_number *= 10
    new_number += number2
    number = number // 10

print(new_number)