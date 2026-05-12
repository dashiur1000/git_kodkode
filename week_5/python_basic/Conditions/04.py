password = "dzs1010@"
your_password = input("enter your password: ")
if your_password == password:
    print("Access Granted")
elif len(your_password) < 8:
    print("Too short")
else:
    print("Wrong password")