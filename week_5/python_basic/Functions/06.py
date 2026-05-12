def count_digits(n):
    sumi = 0
    while n > 0:
        n = n // 10
        sumi += 1
    return sumi

print(count_digits(1000))