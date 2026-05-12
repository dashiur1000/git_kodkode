def digital_root(n):
    str_num = str(n)
    firs_num = 0
    for i in range(len(str_num)):
        int_num = int(str_num[i])
        firs_num += int_num
    str_num = str(firs_num)
    if len(str_num) >= 2:
        n = int(str_num)
        return digital_root(n)
    return str_num


print(digital_root(942))