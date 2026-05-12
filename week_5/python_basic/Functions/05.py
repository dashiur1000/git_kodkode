def digital_root(n):
    str_num = str(n)
    firs_num = 0
    for i in range(len(str_num)):
        int_num = int(str_num[i])
        firs_num += int_num
    str_num = str(firs_num)
    if len(str_num) == 2:
        return sum_digits(str_num)
    elif len(str_num) > 2:
        return digital_root(int(str_num))

def sum_digits(sn):
    sumi = int(sn[0])
    sumi += int(sn[1])
    return sumi


print(digital_root(985))
