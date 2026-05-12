num = 891
result = num%10
num = num//10
result += num%10
num = num // 10
result += num%10

print(result)