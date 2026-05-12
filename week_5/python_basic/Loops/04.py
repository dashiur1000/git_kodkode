text = input("enter your text: ").lower()
sumi = 0
for latter in text:
    if latter in "aeiou":
        sumi += 1
print(sumi)
