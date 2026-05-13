text = input("enter your text: ")
for i in text:
    if "a" < i < "z" or "1" > i < "9":
        a = True
    else:
        a = False
        break
print(a)
