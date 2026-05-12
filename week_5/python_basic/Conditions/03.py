age = int(input("enter your age: "))
vip_card = input("enter yes or no: ")
if age < 16:
    print("No entry")
elif age <= 18 and vip_card == "yes" or age in [19, 20, 21]:
    print("Welcome")