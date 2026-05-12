x = int(input("enter width: "))
y = int(input("enter Length: "))
if x > 50 or y > 80:
    print("Outside the rectangle")
elif x == 10 or y == 20:
    print("On the edge")
elif x < 10 or y < 20:
    print("Too small")
else:
    print("Inside the rectangle")