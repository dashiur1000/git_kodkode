weight = float(input("enter your weight: "))
height = float(input("enter your height: "))/100
bmi = weight/(height**2)
print(f"{bmi:.2f}")