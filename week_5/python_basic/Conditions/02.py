character = input("enter a character: ")
if character.isalpha() and character in "aeiou":
    print("Vowel")
elif "a" <= character <= "z":
    print("Consonant")
else:
    print("Invalid")