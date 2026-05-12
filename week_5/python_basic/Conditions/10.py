score = int(input("enter your score: "))
print("NO" if score > 100 else "A" if score >= 90 else "B" if score >= 80 else "C" if score >= 70 else "F" if score >= 0 else "NO")