import dis
age = int(input("enter an age: "))
if age > 120 or age < 0:
    print("Invalid")
elif age <= 12:
    print("Child")
elif age <= 17:
    print("Teen")
else:
    print("Adult")