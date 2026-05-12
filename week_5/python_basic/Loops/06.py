text = input("enter your text: ")
accumulator = ""
for i in range(len(text)):
    accumulator = text[i] + accumulator
print(accumulator)