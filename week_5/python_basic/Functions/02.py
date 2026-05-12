def factorial(n):
    factorial_all = 1
    for i in range(2, n+1):
        factorial_all *= i
    return factorial_all

print(factorial(5))