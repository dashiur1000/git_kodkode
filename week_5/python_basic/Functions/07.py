def reverse_integer(n):
    str_num = str(n)
    new_num = ""
    for i in range(len(str_num)):
        if str_num[-(i+1)] == "0":
            continue
        new_num += str_num[-(i+1)]
    return new_num

print(reverse_integer(1200))
