your_number = int(input("enter a number: "))
current_number = 100
even = 0
while current_number > 0:
    current_number = your_number - (your_number//10)*10
    your_number = your_number//10
    if current_number !=0 and current_number % 2 == 0:
        even += 1
print(even)

