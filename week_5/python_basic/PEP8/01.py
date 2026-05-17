def calculate_price(items, tax=0.17):
    total = 0
    for i in range(len(items)):
        total = total + i
        total = total * (1 + tax)
    return total

print(2 ** 3 ** 2)